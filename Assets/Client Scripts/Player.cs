using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour, iDamagable<float>
{
    //Damage indicator flashes for set time
    public float DAMAGE_INDICATOR_TIME = 0.85f;

    //Player Script to handle HP, Inventory, Fire Mode, ETC
    public float health = 100f;
    public GameObject gameManager;
    public Transform playerTrans;

    [SerializeField]
    GameObject damageIndicator;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Keeps the Player from flipping over and flying away
        playerTrans.rotation.Set(0, playerTrans.rotation.y, 0, playerTrans.rotation.w);
    }

    public void takeDamage(float damageTaken)
    {
        if (health > damageTaken)
        {
            health -= damageTaken;
            //Update HUD here
            Debug.Log("Player health " + health);
            damageIndicator.SetActive(true);
            StartCoroutine(HideDamageIndicator());
        }
        else
            gameManager.GetComponent<GameManager>().gameOver();
    }

    IEnumerator HideDamageIndicator()
    {
        yield return new WaitForSeconds(DAMAGE_INDICATOR_TIME);
        damageIndicator.SetActive(false);
    }
}
