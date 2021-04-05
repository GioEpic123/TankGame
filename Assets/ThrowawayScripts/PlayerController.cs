using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
 
        if(Input.GetKey(KeyCode.W)) {
            transform.position += Vector3.forward * Time.deltaTime * movementSpeed;
        }
        if(Input.GetKey(KeyCode.S)) {
            rigidbody.position += Vector3.back * Time.deltaTime * movementSpeed;
        }
        if(Input.GetKey(KeyCode.A)) {
            rigidbody.position += Vector3.left * Time.deltaTime * movementSpeed;
        }
        if(Input.GetKey(KeyCode.D)) {
            rigidbody.position += Vector3.right * Time.deltaTime * movementSpeed;
        }
    }
}
