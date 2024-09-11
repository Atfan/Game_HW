using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField]
    private GameObject projectilePrefab;

    [SerializeField] private float shootInterval = 2f;
    [SerializeField] private float radiusLook = 20f;
    [SerializeField]
    private float cooldownTime = 10f;
    [SerializeField]
    private Transform player;
   
    private GameObject currentProjectile; 
    private bool isCoolingDown = false;
    private bool alive = true;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShootRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        if (IsPlayerInSight() && !isCoolingDown)
        {
            if (currentProjectile == null)
            {
                SpawnProjectile();
            }
        }
    }
    private bool IsPlayerInSight()
    {
        float sightRange = radiusLook; 
        float sphereRadius = 1f; 

        Vector3 directionToPlayer = player.position - transform.position;


        if (Physics.SphereCast(transform.position, sphereRadius, directionToPlayer.normalized, out RaycastHit hit, sightRange))
        {
            if (hit.collider.CompareTag("Player"))
            {
                player = hit.collider.transform;
                return true;
            }
        }
    
    
        return false; 
    }
    
    private void SpawnProjectile()
    {
            StartCoroutine(CooldownRoutine());
        currentProjectile =Instantiate(projectilePrefab,new Vector3(this.transform.position.x,3.1f,transform.position.z), Quaternion.identity);
        BallEnemyController  projectileController = currentProjectile.GetComponent<BallEnemyController>();
        if (projectileController != null)
        {
            projectileController.SetTarget(player);
        }
    }
    
    

    private IEnumerator ShootRoutine()
    {
        while (true)
        {
            if (currentProjectile == null && !isCoolingDown)
            {
                SpawnProjectile();
                yield return new WaitForSeconds(shootInterval);
            }
            else
            {
                yield return null;
            }
        }
    }

    private IEnumerator CooldownRoutine()
    {
        isCoolingDown = true;
        yield return new WaitForSeconds(cooldownTime);
        isCoolingDown = false;
    }
    
    public void ReactToTit()
    {

        if (!alive)
        {
            return;
        }

        Debug.Log("Target hit");
    }
   
}
