using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallEnemyController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField]
    private float lifetime = 10f;
    [SerializeField]
    private float straightMovementTime = 1f; 

    private Transform target;
    private Vector3 straightDirection;
    private bool isMovingStraight = false;
    private float timeMoved = 0f;

    private void Start()
    {
        Destroy(gameObject, lifetime); 
        if (target != null)
        {
            straightDirection = (target.position - transform.position).normalized;
        }
    }

    private void Update()
    {
        if (target != null)
        {
           
            
            transform.Translate(straightDirection * speed * Time.deltaTime, Space.World);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //other.
            Destroy(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
