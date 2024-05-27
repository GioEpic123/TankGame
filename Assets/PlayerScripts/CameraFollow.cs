using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform initialTrans;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        initialTrans = this.transform;
        player = FindObjectOfType<PlayerScript>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(player.transform.position);
        transform.position = player.transform.position + new Vector3(25, 25, -25);

    }
}
