using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookPlayer : MonoBehaviour
{
        
    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    
    [SerializeField]
    private RotationAxes axes = RotationAxes.MouseXAndY;
    
    [SerializeField] 
    private float sensitivityX = 9f;
    [SerializeField]
    private float sensitivityY = 9f;
   
    [SerializeField] 
    private float maxVertAngle = 45f;
    [SerializeField]
    private float minVertAngle = -45f;
    private float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
        {
            body.freezeRotation = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (axes == RotationAxes.MouseX || axes == RotationAxes.MouseXAndY)
        {
            transform.Rotate(0f, Input.GetAxis("Mouse X") * sensitivityX * Time.deltaTime * 40, 0f);
        }

        if (axes == RotationAxes.MouseY || axes == RotationAxes.MouseXAndY)
        {
            xRotation -= Input.GetAxis("Mouse Y") * sensitivityY * Time.deltaTime * 20;
            xRotation = Mathf.Clamp(xRotation, minVertAngle, maxVertAngle);

            float yRotation = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(xRotation, yRotation, 0f);
        }

    }
}
