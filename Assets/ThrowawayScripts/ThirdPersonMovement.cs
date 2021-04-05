using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;

    //Player base used to rotate actual player and determine motion, player gun for rotating gun seperately
    public GameObject playerBase;
    public GameObject playerGun;

    public float speed = 6f;
    public float rotationSpeed = 120f;

    public float turnSmoothTime = 0.1f;
    public float turnSmoothVelocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        //Vector3 direction = new Vector3(0f, 0f, vertical).normalized;
        //Vector3 rotation = new Vector3(0f, horizontal, 0f).normalized;

        if(direction.magnitude >= 0.1f){
            
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir * speed * Time.deltaTime);

        }
        // if(rotation.magnitude >= 0.1f){
        //     controller.GetComponentInParent<Transform>().Rotate(rotation * rotationSpeed * Time.deltaTime);
        // }
    }
}
