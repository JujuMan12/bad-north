using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap : MonoBehaviour
{
    [Header("Map")]
    [SerializeField] private SquadManager squadManager;
    [SerializeField] private TileComponent[] tiles;

    private void Start()
    {
        foreach (TileComponent tile in tiles)
        {
            tile.squadManager = squadManager;
        }
    }
}
