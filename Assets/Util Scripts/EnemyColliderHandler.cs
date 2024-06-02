using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColliderHandler : MonoBehaviour
{
    //Enemiy's main hitbox is used to detect damage
    //This is for hurtbox components (children) to notify Enemy script of damage dealt 

    Enemy parentScript;
    void Start()
    {
        parentScript = GetComponentInParent<Enemy>();
    }

    //Notify parent if player ...
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            parentScript.PlayerInRange(other.gameObject);
        }
    }

}
