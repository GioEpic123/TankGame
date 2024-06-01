
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Entity
{
    //Enemies meele when close

    float MEELE_COOLDOWN_TIME = 1.2f;
    public float meeleDamage = 25;

    bool canMeele;

    void Start()
    {
        canMeele = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && canMeele)
        {
            other.gameObject.GetComponent<Player>().takeDamage(meeleDamage);
            canMeele = false;
            StartCoroutine(AttackCooldown());
        }
    }

    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(MEELE_COOLDOWN_TIME);
        canMeele = true;
    }
}
