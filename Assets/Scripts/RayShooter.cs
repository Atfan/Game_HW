using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    [SerializeField]
    private GUIStyle _style;
    private Camera _camera;
    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();
        if (_camera == null)
        {
            Debug.LogError("No camera attached");
            return;
        }
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 center = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2,0);

            Ray ray = _camera.ScreenPointToRay(center);

            RaycastHit hitInfo;
            if (Physics.Raycast( ray, out hitInfo))
            {
                //Debug.Log($" Hit: {hitInfo.point.ToString()}");

                StartCoroutine(CreateSphereIndicator(hitInfo.point));
                
                GameObject hitObject = hitInfo.transform.gameObject;
                TurretController target = hitObject.GetComponent<TurretController>();
                if (target != null)
                {
                    target.ReactToTit();
                }
            }
            else
            {
                Debug.Log("No raycast");
            }
        }
    }

    private IEnumerator CreateSphereIndicator(Vector3 hitInfoPoint)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = hitInfoPoint;
        
        yield return new WaitForSeconds(1f);
        Destroy(sphere);
    }

    private void OnGUI()
    {
        float size = _style.fontSize;
        float x = (_camera.pixelWidth / 2) - (size / 2);
        float y = (_camera.pixelHeight / 2) - (size / 2);
        GUI.Label(new Rect(x, y, size, size), "-|-", _style);
    }
}
