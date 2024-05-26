using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iEnemy : MonoBehaviour, iDamagable<float>
{
    //All Enemies will have a health, speed, and damage
    public float health = 25;
    public float speed = 5;
    public float attackDamage = 25;

    public Vector3 spawnLocation;// { get; set; } // To be set by Room when spawning object
    public GameObject myRoom;//This objects room

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(float damageTaken)
    {
        if (health > damageTaken)
        {
            health -= damageTaken;
            //animate damage taken (pop up above enemy saying "-10" or something 
            Debug.Log("Enemy took " + damageTaken + " Damage!");
        }
        else
            die();
    }

    void die()
    {
        Debug.Log("Enemy Died!");
        //Drop items,
        //Perform death animation
        myRoom.GetComponent<RoomObj>().removeActiveEnemy(gameObject); // - Remove from myRoom as active enemy
     
        
        Destroy(this.gameObject);//Should do this as last action when enemy has dissapeared
        
        
    }
    

}
