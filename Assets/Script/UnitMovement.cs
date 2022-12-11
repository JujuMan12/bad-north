using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitMovement : MonoBehaviour
{
    [HideInInspector] private Transform navTarget;

    [Header("Navigation")]
    [SerializeField] public NavMeshAgent navMeshAgent;

    private void FixedUpdate()
    {
        if (navTarget)
        {
            navMeshAgent.destination = navTarget.position;
        }
    }

    public void SetNavTarget(Transform target)
    {
        navTarget = target;
    }
}
