using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpiderPigMovement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform position1;
    [SerializeField] private Transform position2;
    private Vector3 currentDestination;
    private bool isChasing = false;

    private void Awake()
    {
        PlaytipusMovement.LowOnHealth += StartChasing;
        PlaytipusMovement.GotBugSpray += StartPatroling;
    }

    void Start()
    {
        currentDestination = position1.position;
        agent.SetDestination(currentDestination);
    }

    private void StartChasing()
    {
        isChasing = true;
    }

    private void StartPatroling()
    {
        isChasing = false;
    }

    private void Update()
    {
        if (isChasing)
        {
            FollowPlayer();
        }
        else
        {
            Patrol();
        }
    }

    private void Patrol()
    {
        if (agent.remainingDistance < 0.75f)
        {
            if (currentDestination == position1.position)
            {
                currentDestination = position2.position;
            }
            else
            {
                currentDestination = position1.position;
            }
            agent.SetDestination(currentDestination);
        }
    }

    private void FollowPlayer()
    {
        agent.SetDestination(PlaytipusMovement.GetInstance().transform.position);
    }
}
