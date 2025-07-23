using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerInputs))]

public class PlayerController : MonoBehaviour
{
    [Header("Movement Properties")]
    public float tankSpeed;
    public float tankRotationSpeed;
    public float gunRotationSpeed;

    private Rigidbody playerBody;
    private PlayerInputs playerInput;

    public GameObject recticle;
    public Transform playerGunTrans;
    public Transform playerTrans;
    public GameObject gunBarell;

    GunBehavior gunBehavior;




    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInputs>();

        // //TODO: Dynamic gun types won't work with this.
        // try
        // {
        //     gunBehavior = transform.Find("TankGun").GetComponent<GunBehavior>();
        // }
        // catch (System.Exception)
        // {
        //     Debug.Log("Can't find 'Tank Gun', did you rename it?");
        //     throw;
        // }

        gunBehavior = transform.GetChild(0).GetComponent<GunBehavior>();
    }

    void FixedUpdate()//To be used rather than update when altering RigidBody
    {
        if (playerBody && playerInput)
        {
            handleMovement();
        }
    }

    void Update()
    {
        if (playerInput)
        {
            handleShootingInput();
        }
    }

    void handleShootingInput()
    {
        //Tell our GunBehavior to shoot
        if (playerInput.getFireInput)
        {
            gunBehavior.Fire();
        }

        if (playerInput.getSecFireInput)
        {
            gunBehavior.Fire2();
        }
    }

    void handleMovement()
    {

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
        if (playerGunTrans)
        {
            Vector3 gunLookDir = playerInput.getRecticlePosition - playerGunTrans.position;
            gunLookDir.y = 0f;

            playerGunTrans.rotation = Quaternion.LookRotation(gunLookDir);
        }
    }
}

