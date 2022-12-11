using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [HideInInspector] private Vector3 targetPosition;
    [HideInInspector] private bool unitsDeployed;

    [Header("Ship")]
    [SerializeField] private float movementSpeed = 0.2f;
    [SerializeField] private UnitComponent[] units;
    [SerializeField] private GameObject shipModel;

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, movementSpeed * Time.deltaTime);
    }

    public void SetCoastalTile(TileComponent tile)
    {
        targetPosition = tile.transform.position;
        transform.LookAt(targetPosition);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Tile") && !unitsDeployed)
        {
            DeployUnits();
        }
    }

    private void DeployUnits()
    {
        unitsDeployed = true;

        foreach (UnitComponent unit in units)
        {
            unit.unitMovement.enabled = true;
            unit.unitMovement.navMeshAgent.enabled = true;
            unit.unitCombat.enabled = true;
        }

        shipModel.SetActive(false);
    }
}
