using UnityEngine;

public class GunBehavior : MonoBehaviour
{
    public Transform GunBarrel;
    public GameObject gunUser;
    private float nextShootTime = 0f;

    public GameObject bulletPrefab;

    public float bulletSpeed = 25;
    public float bulletDelay = 0.5f;      //Time between shots 

    Rigidbody bullet;

    private float damagePerBullet = 10f; //will be affected by bullet type, as well as bullet delay & speed

    public void Start()
    {
        bullet = bulletPrefab.transform.GetChild(0).GetComponent<Rigidbody>();
    }

    public void Fire()
    {
        if (nextShootTime <= Time.time)
        {
            //Clone & send bullet
            Rigidbody bulletClone = Instantiate(bullet, GunBarrel.position, GunBarrel.rotation);
            bulletClone.velocity = GunBarrel.forward * bulletSpeed;
            //Set Bullet's properties
            BulletBehavior cloneScript = bulletClone.gameObject.GetComponent<BulletBehavior>();
            cloneScript.damage = damagePerBullet;
            cloneScript.bulletSource = gunUser;
            //Shoot delay
            nextShootTime = Time.time + bulletDelay;
        }
        else
        {
            //To-Do: Give a signal to user
        }
    }

    public void Fire2()
    {
        Debug.Log("Alt-fire! Not yet configured :)");
    }


}
