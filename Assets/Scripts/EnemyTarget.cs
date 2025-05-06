using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTarget : MonoBehaviour
{
    [SerializeField] private Transform target;
    private NavMeshAgent navAgent;

    private void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        navAgent.destination = target.position;
    }
}
