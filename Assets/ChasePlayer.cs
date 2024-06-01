using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class ChasePlayer : MonoBehaviour
{
    GameObject player;
    NavMeshAgent agent;
    public float moveSpeed = 5;

    void Start()
    {
        player = GameManager.getPlayer;
        agent = GetComponent<NavMeshAgent>();
        if (agent)
            agent.speed = moveSpeed;
    }

    void Update()
    {
        // Look code (needs smooth look)
        //Vector3 playerPosAdj = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        //transform.LookAt(playerPosAdj);
        if (agent)
            agent.SetDestination(player.transform.position);
    }
}
