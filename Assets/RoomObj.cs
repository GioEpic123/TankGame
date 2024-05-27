using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomObj : MonoBehaviour
{
    //Room object randomly decides which types of enemies, size, and loot to contain within it on startup
    //Room lies dormant until player owns the room, in which case startRoom() gets called, and all enemies spawn in
    //Enemies alive are stored within the room, and once all enemies have been terminated, the room's status is Clear

    /*
     1 - Random gen chooses which rooms go where 
     2 - Build room
     
     3 - chooseEnemies 
    
        == Room Activation
     
     1 - room state changes
     2 - enemies spawn in
     3 - (IF) no more enemies, room clears, spawn loot
     */

    enum roomState {
        idle,
        active,
        clear
    }
    private roomState state = roomState.idle;
    
    private Transform roomMiddle; //The center of the room, used for spawning
    private ArrayList doors = new ArrayList();//An array of doors to be set on room build, for use with locking & unlocking doors
    private Collider roomBoxColli;

    
    private ArrayList enemyBlueprint = new ArrayList(); // Blueprint for which objects to generate
    private ArrayList activeEnemies = new ArrayList();
 
    public GameObject cratePref; // Prefab to work as an enemy for testing.
    public GameObject lootPref; // Loot prefab for testing, will be changed to a loot table late

    // -- CURRENTLY UNUSED MEMBERS

    //private int roomType = 0;//For different room types, to be used later
    //double lootDropMult; // Value for calculating loot drops


    // Start is called before the first frame update
    void Start()
    {
        buildRoom();
        chooseEnemies();
        //Decide type of loot

    }

    // Update is called once per frame
    void Update()
    {
        //Checks if Room is Clear
        if(state == roomState.active)
        {
            if(activeEnemies.Count <= 0)
            {
                clearRoom();
            }
        }
    }

    void buildRoom()
    {
        roomBoxColli = GetComponent<Collider>();
        doors.Add(transform.GetChild(1).transform.GetChild(0).gameObject);
        doors.Add(transform.GetChild(2).transform.GetChild(0).gameObject);
        doors.Add(transform.GetChild(3).transform.GetChild(0).gameObject);
        doors.Add(transform.GetChild(4).transform.GetChild(0).gameObject);
        roomMiddle = transform.GetChild(0).GetChild(0);


        // !! - Spawn doors & pathways to and from, build according to room type


        foreach (GameObject door in doors)
        {
            //Have doors perform animation on lock and unlock
            door.SetActive(false);
        }
    }

    /** chooseEnemies()
    *   - On map build, chooses which enemies to spawn when room becomes active
    */
    void chooseEnemies()
    {
        //Decide which enemies to spawn, load them into enemies[];
        enemyBlueprint.Add(cratePref);
        //TODO- move this setup to enemies themselves 
        ((GameObject)enemyBlueprint[0]).GetComponent<iEnemy>().spawnLocation = roomMiddle.position;
        ((GameObject)enemyBlueprint[0]).GetComponent<iEnemy>().myRoom = this.gameObject;
    }

    public void OnTriggerEnter(Collider other)
    {

        if(other.CompareTag("Player") && state == roomState.idle)
        {
            state = roomState.active;
            other.GetComponent<PlayerScript>().setRoom(this.gameObject);
            activateRoom();
            Destroy(roomBoxColli);
        }
    }

    public void activateRoom()
    {
        Debug.Log("Room Start!");
        
        foreach(GameObject go in enemyBlueprint)
        {

            GameObject temp = Instantiate(go);
            activeEnemies.Add(temp);
            Debug.Log("Enemy Count: " + activeEnemies.Count);
            temp.transform.position = roomMiddle.position;
            temp.GetComponent<iEnemy>().myRoom = this.gameObject;
        }
        
        foreach (GameObject door in doors)
        {
            door.SetActive(true);
        }

    }

    public void clearRoom()
    {
        Debug.Log("Room Clear!");
        state = roomState.clear;
        GameObject temp = Instantiate(lootPref);
        temp.transform.position = roomMiddle.position;
        toggleDoors();
    }

    public void removeActiveEnemy(GameObject enem)
    {
        activeEnemies.Remove(enem);
        Debug.Log("Remove Sucessful");
    }

    public void toggleDoors()
    {
        bool active = ((GameObject)doors[0]).activeSelf;
        foreach (GameObject door in doors)
        {
            door.SetActive(!active);
            // !! - Animations for door open and close
        }
    }

    
}
