using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour {

    private NavMeshAgent agent;
    public Transform player;

    public float playerDetectionRange;

    bool playerIsSeen;

    private void Start()
    {
        agent = transform.GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        Collider[] hitCollider = Physics.OverlapSphere(gameObject.transform.position, playerDetectionRange);

        foreach(Collider hit in hitCollider)
        {
            if(hit.name == "player_player")
            {
                playerIsSeen = true;
            }
        }

        if (playerIsSeen)
        {
            print("Player is in the overlapSphere");
            agent.SetDestination(player.transform.position);
        }
        else
        {
            print("Player is out of the overlapSphere");
            agent.SetDestination(gameObject.transform.position);
        }


    }
}
