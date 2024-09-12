using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpiderPigMovement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Vector3 position1;
    [SerializeField] private Vector3 position2;
    private Vector3 currentDestination;
    void Start()
    {
        currentDestination = position1;
        agent.SetDestination(currentDestination);
    }

    private void Update()
    {

    }

    private void Patrol()
    {
        if (agent.remainingDistance < 0.75f)
        {
            if (currentDestination == position1)
            {
                currentDestination = position2;
            }
            else
            {
                currentDestination = position1;
            }
            agent.SetDestination(currentDestination);
        }
    }

    private void FollowPlayer()
    {
        agent.SetDestination(PlaytipusMovement.GetInstance().transform.position);
    }
}
