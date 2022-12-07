using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquadController : MonoBehaviour
{
    [HideInInspector] public SquadManager squadManager;
    [HideInInspector] private TileComponent targetTile;

    [Header("Squad")]
    [SerializeField] private UnitMovement[] units;

    private void Start()
    {
        foreach (UnitMovement unit in units)
        {
            unit.squadController = this;
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetButtonDown("Select Squad") && squadManager.selectedSquad != this)
        {
            squadManager.SelectSquad(this);
        }
    }

    public void SetTargetTile(TileComponent tile)
    {
        targetTile = tile;
        UpdateNavTarget();
    }

    public void UpdateNavTarget()
    {
        for (int i = 0; i < units.Length; i++)
        {
            if (units[i])
            {
                units[i].navTarget = targetTile.tilePositions[i];
            }
        }
    }
}
