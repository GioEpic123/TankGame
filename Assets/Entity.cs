using UnityEngine;

public class Entity : MonoBehaviour, iDamagable<float>
{
    public float health = 25;

    //For Drops:
    // - create an item object class
    // - use some sort of loottable system...
    public GameObject[] drops;
    public GameObject myRoom;

    public void takeDamage(float damageTaken)
    {
        if (health > damageTaken)
        {
            health -= damageTaken;
            //animate damage taken (pop up above enemy saying "-10" or something 
            DisplayHealth();
        }
        else
            Die();
    }

    void DisplayHealth()
    {
        Debug.Log($"Entity at {health} hp!");
        // use some pop-up UI element
    }

    void Die()
    {
        Debug.Log("Enemy Died!");
        //Drop items,
        //Perform death animation

        if (myRoom)
            myRoom.GetComponent<RoomObj>().removeActiveEnemy(gameObject); // - Remove from myRoom as active enemy

        Destroy(this.gameObject);//Should do this as last action when enemy has dissapeared
    }
}
