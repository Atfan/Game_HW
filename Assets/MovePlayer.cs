using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class MovePlayer : MonoBehaviour
{
    [SerializeField] 
    private float speed = 6.0f;
    [SerializeField] 
    private float gravity = 9.8f;
    
    private CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal")*speed;
        float vertical = Input.GetAxis("Vertical") * speed;
           
        Vector3 movement = new Vector3(horizontal,gravity*(-1f),vertical);
        movement = Vector3.ClampMagnitude(movement,speed);
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        controller.Move(movement);
    }
}
