using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitMovement : MonoBehaviour
{
    [HideInInspector] public Transform navTarget;
    [HideInInspector] public SquadController squadController;

    [Header("Navigation")]
    [SerializeField] public NavMeshAgent navMeshAgent;

    private void FixedUpdate()
    {
        if (navTarget)
        {
            navMeshAgent.destination = navTarget.position;
        }
    }
}
