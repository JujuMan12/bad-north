using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquadController : MonoBehaviour
{
    [HideInInspector] public SquadManager squadManager;
    [HideInInspector] public TileComponent targetTile;

    [Header("Squad")]
    [SerializeField] private UnitMovement[] units;

    private void Start()
    {
        foreach (UnitMovement unit in units)
        {
            unit.squadController = this;
        }
    }

    public void SelectThisSquad()
    {
        squadManager.selectedSquad?.ClearTargetTileHighlight();

        squadManager.SelectSquad(this);
        HighlightTargetTile();
    }

    public void SetTargetTile(TileComponent tile)
    {
        ClearTargetTileHighlight();

        targetTile = tile;
        HighlightTargetTile();

        UpdateNavTarget();
    }

    public void ClearTargetTileHighlight()
    {
        targetTile.SetColor(TileComponent.ColorState.none);
    }

    public void HighlightTargetTile()
    {
        targetTile.SetColor(TileComponent.ColorState.highlight);
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
