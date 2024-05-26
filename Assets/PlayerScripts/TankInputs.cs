using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankInputs : MonoBehaviour
{
    //Camera for use with Recticle movement
    public Camera camera;

    private Vector3 recticlePosition;
    public Vector3 getRecticlePosition{
        get { return recticlePosition; } 
    }

    private Vector3 recticleNormal;
    public Vector3 getRecticleNormal{
        get { return recticleNormal; } 
    }

    private float forwardInput;
    public float getForwardInput{
        get { return forwardInput; }
    }

    private float rotationInput;
    public float getRotationInput{
        get { return rotationInput; }
    }

    // Update is called once per frame
    void Update()
    {
        if(camera){
            handleInputs();
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(recticlePosition, 0.5f);
    }

    protected virtual void handleInputs(){

        Ray screenRay = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(screenRay, out hit)){//If Raycast hits a collider, returns true and stores data into "hit"

            recticlePosition = hit.point;//Put Recticle at the position of the hit
            
            //Find a way to Debug.Log() the target object for bug fixing

            recticleNormal = hit.normal;//Point the rectacle at the normal of the hit (i.e. the direction of the surface)
            //Debug.Log(hit.collider.gameObject);
        }
        
        forwardInput = Input.GetAxis("Vertical");
        rotationInput = Input.GetAxis("Horizontal");
    }
}
