using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(TankInputs))]

public class TankController : MonoBehaviour
{
    [Header("Movement Properties")]
    public float tankSpeed;
    public float tankRotationSpeed;
    public float gunRotationSpeed;

    private Rigidbody playerBody;
    private TankInputs playerInput;

    public GameObject recticle;
    public Transform playerGunTrans;
    public Transform playerTrans;
    public GameObject gunBarell;


    

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
        playerInput = GetComponent<TankInputs>();

    }

    void FixedUpdate()//To be used rather than update when altering RigidBody
    {
        if(playerBody && playerInput){
            handleMovement();
        }
    }

    void handleMovement(){

        /*
        //Dead Solution to barrier - might use later
        if (!Physics.Raycast(transform.position, transform.forward, 2f) || !Physics.Raycast(transform.position, -transform.forward, 2f))
        {
            Vector3 nextPosition = transform.position + (transform.forward * playerInput.getForwardInput * tankSpeed * Time.deltaTime);
            playerBody.MovePosition(nextPosition);
        }
        else
        {
            // hit a wall, do something else!
        }
        */

        //Makes a position set to the position plus it's displacement(decided by input)
        Vector3 nextPosition = transform.position + (transform.forward * playerInput.getForwardInput * tankSpeed * Time.deltaTime);
        playerBody.MovePosition(nextPosition);

        //Rotate the tank
        Quaternion nextRotation = transform.rotation * Quaternion.Euler(Vector3.up * playerInput.getRotationInput * tankRotationSpeed);
        playerBody.rotation = nextRotation;

        //Place the recticle
        recticle.transform.position = playerInput.getRecticlePosition;
            //--For Recticle rotation, save if we want recticle on walls or something--//
            // recticle.transform.rotation = Quaternion.Euler(recticle.transform.rotation.eulerAngles.x, playerInput.getRecticleNormal.y, transform.rotation.eulerAngles.z);
        
        //Rotate the Gun
        if(playerGunTrans){
            Vector3 gunLookDir = playerInput.getRecticlePosition - playerGunTrans.position;
            gunLookDir.y = 0f;

            playerGunTrans.rotation = Quaternion.LookRotation(gunLookDir);
        }

       
            
            
            //.rotation.SetEulerRotation(0, 0, 0);
            //Set(0, playerTrans.rotation.y, 0, playerTrans.rotation.w);
    }
}

