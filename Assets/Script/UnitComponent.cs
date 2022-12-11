using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitComponent : MonoBehaviour
{
    [HideInInspector] public SquadController squadController;

    [Header("Unit")]
    [SerializeField] public UnitMovement unitMovement;
    [SerializeField] public UnitCombat unitCombat;

    private void Start()
    {
        unitCombat.unitComponent = this;
    }

    private void OnMouseOver()
    {
        if (Input.GetButtonDown("Select Squad") && squadController)
        {
            squadController.SelectThisSquad();
        }
    }
}
