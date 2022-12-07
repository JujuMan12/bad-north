using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileComponent : MonoBehaviour
{
    [HideInInspector] public SquadManager squadManager;

    [Header("Tile")]
    [SerializeField] public Transform[] tilePositions;

    private void OnMouseOver()
    {
        if (Input.GetButtonDown("Order Squad") && squadManager.selectedSquad)
        {
            squadManager.selectedSquad.SetTargetTile(this);
        }
    }
}
