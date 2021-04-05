using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float damage;
    public Collider hitbox;


    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("HI ");
    }

    // Update is called once per frame
    void Update()
    {
        //Keeps all bullets at the same height regardless of non-damaging collisions (makes for fun bullet physics)
        this.gameObject.transform.position = new Vector3(transform.position.x, 1.5f, transform.position.z);
        handleCollisions();
    }

    void handleCollisions()
    {
        //If object is part of damagable, take damage, however ignore player hitbox
        //Subclasses of BulletBehavior (I.E. EnemyBulletBehavior or ExplosiveBulletBehavior) will include player hitboxes and exclude their own

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<iDamagable<float>>() != null && other.gameObject.tag != "Player")//If its a member of idamageable & NOT the player
        {
            Debug.Log("Bullet Hit " + other.gameObject.name);
            other.gameObject.GetComponent<iDamagable<float>>().takeDamage(damage);
            Destroy(this.gameObject);
        }
    }

}
