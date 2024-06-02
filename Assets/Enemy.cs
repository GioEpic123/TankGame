
using System.Collections;
using UnityEngine;

public class Enemy : Entity
{
    //Enemies meele when close

    //New onboarding enemy checklist:
    // - Set it's layers to ignoreRaycast for player recticle
    // - Give it a hurtbox low enough to dodge bullets (for this script)
    // - Set all interactable (colliders, etc) objects within enemy pref to "Enemy" tag

    float MEELE_COOLDOWN_TIME = 1.2f;
    public float meeleDamage = 25;

    bool canMeele;

    void Start()
    {
        canMeele = true;
    }

    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(MEELE_COOLDOWN_TIME);
        canMeele = true;
    }

    public virtual void PlayerInRange(GameObject player)
    {
        if (canMeele)
        {
            player.GetComponent<Player>().takeDamage(meeleDamage);
            canMeele = false;
            StartCoroutine(AttackCooldown());
        }
    }
}
