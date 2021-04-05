using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehavior : MonoBehaviour
{

    //Find the angle the gun is pointing, spawn a bullet object
    //Make the bullet object point the same way as the gun, spawn on click 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            Fire();

    }

    


    public float bulletSpeed = 25;
    public float bulletDelay = 0.5f;      //Time between shots 
    private float nextBulletTime = 0f; //Time Next shot can be fired

    private float bulletDamage = 10f; //will be affected by bullet type, as well as bullet delay & speed


    public Rigidbody bullet;

    public Transform GunBarrel;


    void Fire()
    {

        if (nextBulletTime <= Time.time)
        {
            //Actual bullet Shot
            //Rigidbody bulletClone = (Rigidbody)Instantiate(bullet, transform.position, transform.rotation);
            //bulletClone.velocity = transform.forward * bulletSpeed;
            Rigidbody bulletClone = (Rigidbody)Instantiate(bullet, GunBarrel.position, GunBarrel.rotation);
            bulletClone.velocity = GunBarrel.forward * bulletSpeed;
            bulletClone.gameObject.GetComponent<BulletBehavior>().damage = bulletDamage;
            //
            nextBulletTime = Time.time + bulletDelay;
            Debug.Log("Take a shot");
        }
        else
        {
            Debug.Log("Bullet Cooldown");
        }
    }


}
