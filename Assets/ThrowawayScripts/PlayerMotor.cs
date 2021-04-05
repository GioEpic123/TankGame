using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    public float movementSpeed = 50f;
    public Rigidbody playerBody; 
    public Transform playerTrans;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W)) {
            playerBody.velocity = transform.forward * movementSpeed;
            //transform.position += Vector3.forward * Time.deltaTime * movementSpeed;
        }else{

        }
        // if(Input.GetKey(KeyCode.S)) {
        //     rigidbody.position += Vector3.back * Time.deltaTime * movementSpeed;
        // } 
    }
}
