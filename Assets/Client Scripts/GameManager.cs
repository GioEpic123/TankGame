using UnityEngine;
public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;
    static GameObject player = null;
    public static GameObject getPlayer
    {
        get { return player; }
    }

    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        if (!player)
        {
            player = transform.parent.GetChild(0).gameObject;
        }
    }

    public void gameOver()
    {
        Debug.Log("Game Over!");
        //Display Death Screen, along with menu
    }

}
