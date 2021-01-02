using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    Transform target;

    NavMeshAgent agent;

    void Awake()
    {
        Initialize();
    }

    void LateUpdate()
    {
        FollowTarget();
    }

    void Initialize()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void FollowTarget()
    {
        agent.SetDestination(target.position);
    }
}

