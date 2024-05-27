using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehavior : MonoBehaviour
{

    //TODO- Move logic to "StandardGun", make this an interface

    

    public float bulletSpeed = 25;
    public float bulletDelay = 0.5f;      //Time between shots 
    private float nextShootTime = 0f; 

    private float damagePerBullet = 10f; //will be affected by bullet type, as well as bullet delay & speed


    public Rigidbody bullet;

    public Transform GunBarrel;


    public void Fire()
    {
        Debug.Log("Shooting!");
        if (nextShootTime <= Time.time)
        {
            Rigidbody bulletClone = Instantiate(bullet, GunBarrel.position, GunBarrel.rotation);
            bulletClone.velocity = GunBarrel.forward * bulletSpeed;
            bulletClone.gameObject.GetComponent<BulletBehavior>().damage = damagePerBullet;
            nextShootTime = Time.time + bulletDelay;
        }
        else
        {
            //To-Do: Give a signal to user
        }
    }

    public void Fire2(){
        Debug.Log("Alt-fire! Not yet configured :)");
    }


}
