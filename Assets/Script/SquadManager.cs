using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquadManager : MonoBehaviour
{
    [HideInInspector] public SquadController selectedSquad;

    [Header("Initialisation")]
    [SerializeField] private GameObject[] initialSquads;
    [SerializeField] private TileComponent[] initialTiles;

    private void Start()
    {
        SpawnSquads();
    }

    private void SpawnSquads()
    {
        for (int i = 0; i < initialSquads.Length; i++)
        {
            GameObject newSquad = Instantiate(initialSquads[i], initialTiles[i].transform.position, Quaternion.identity, transform);
            SquadController newSquadController = newSquad.GetComponent<SquadController>();

            newSquadController.squadManager = this;
            newSquadController.targetTile = initialTiles[i];
        }
    }

    public void SelectSquad(SquadController squad)
    {
        selectedSquad = squad;
    }
}
