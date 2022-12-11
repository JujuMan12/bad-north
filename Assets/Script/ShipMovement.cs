using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [HideInInspector] private Vector3 targetPosition;
    [HideInInspector] private TileComponent targetTile; //TODO: удалить

    [Header("Ship")]
    [SerializeField] private float movementSpeed = 0.2f;
    [SerializeField] private UnitMovement[] units;
    [SerializeField] private GameObject shipModel;

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, movementSpeed * Time.deltaTime);
    }

    public void SetCoastalTile(TileComponent tile)
    {
        targetTile = tile; //TODO: удалить
        targetPosition = tile.transform.position;
        transform.rotation.SetLookRotation(targetPosition - transform.position);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Tile"))
        {
            DeployUnits();
        }
    }

    private void DeployUnits()
    {
        targetPosition = transform.position;

        foreach (UnitMovement unit in units)
        {
            unit.enabled = true;
            unit.navMeshAgent.enabled = true;
            unit.navTarget = targetTile.tilePositions[0]; //TODO
        }

        shipModel.SetActive(false);
    }
}
