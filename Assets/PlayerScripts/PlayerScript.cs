using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour, iDamagable<float>
{

    //Player Script to handle HP, Inventory, Fire Mode, ETC
    public float health = 100f;
    public GameObject gameManager;
    public Transform playerTrans;
    public GameObject currentRoom;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Keeps the Player from flipping over and flying away
        playerTrans.rotation.Set(0, playerTrans.rotation.y, 0,playerTrans.rotation.w);
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

    //TODO: Do we need this?
    public void setRoom(GameObject room)
    {
        if (currentRoom != room)
            currentRoom = room;
    }
}
