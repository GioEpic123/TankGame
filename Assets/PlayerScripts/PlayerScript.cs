using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour, iDamagable<float>
{

    //Player Script to handle HP, Inventory, Fire Mode, ETC
    public float health = 100f;
    public GameObject gameManager;

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
            //Update HUD health
        }  
        else
            gameManager.GetComponent<GameManager>().gameOver();
    }
}
