
using UnityEngine;

public class Wormett : Enemy
{
    //Wormetts lock-on to player in range, follow till out of range, firing continuously
    //Can be sabotaged to shoot itself

    //May change from an area-based detection to raytracing for dynamic size (??)
    GunBehavior gunBehavior;
    [SerializeField]
    GameObject targetingIndicator, gun;
    [SerializeField]
    Material targetingMaterial, neutralMaterial; // Consider making this globally avaliable for reuse?
    // Update is called once per frame
    bool isTargeting = false;
    GameObject player;
    void Start()
    {
        gunBehavior = gun.GetComponent<GunBehavior>();
    }

    void FixedUpdate()
    {
        //use isTargeting to flash the indicator
    }

    public override void PlayerInRange(GameObject player)
    {
        if (!player)
        {
            this.player = player;
        }

        gun.transform.LookAt(new Vector3(player.transform.position.x, 1.5f, player.transform.position.z));
        gunBehavior.Fire();

    }
}
