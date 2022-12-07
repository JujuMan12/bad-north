using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [HideInInspector] private float timeToNextWave;
    [HideInInspector] private int remainingWaves;
    [HideInInspector] private List<Transform> unusedSpawnPoints;

    [Header("Waves")]
    [SerializeField] private GameObject shipPrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float startCooldown = 2f;
    [SerializeField] private int waveCount = 3;
    [SerializeField] private float waveCooldown = 10f;
    [SerializeField] private int shipCount = 2;

    private void Start()
    {
        timeToNextWave = startCooldown;
        remainingWaves = waveCount;
        unusedSpawnPoints = new List<Transform>();
    }

    private void FixedUpdate()
    {
        if (remainingWaves > 0)
        {
            CountSpawnCooldown();
        }
    }

    private void CountSpawnCooldown()
    {
        if (timeToNextWave <= 0f)
        {
            SpawnWave();
        }
        else
        {
            timeToNextWave -= Time.deltaTime;
        }
    }

    private void SpawnWave()
    {
        unusedSpawnPoints.Clear();
        unusedSpawnPoints.AddRange(spawnPoints);

        for (int i = 0; i < shipCount; i++)
        {
            SpawnShip();
        }

        timeToNextWave = waveCooldown;
        remainingWaves -= 1;
    }

    private void SpawnShip()
    {
        int spawnPointId = Random.Range(0, unusedSpawnPoints.Count);
        Transform spawnPoint = unusedSpawnPoints[spawnPointId];

        GameObject newShip = Instantiate(shipPrefab, spawnPoint.position, Quaternion.identity, spawnPoint);
        ShipMovement shipMovement = newShip.GetComponent<ShipMovement>();

        TileComponent coastalTile = spawnPoint.GetComponent<SpawnPointComponent>().coastalTile;
        shipMovement.SetCoastalTile(coastalTile);
    }
}
