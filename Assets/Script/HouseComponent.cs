using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseComponent : MonoBehaviour
{
    [HideInInspector] private int healthPoints;
    [HideInInspector] public HouseManager houseManager;

    [Header("House")]
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private TMPro.TextMeshPro healthCounter;
    [SerializeField] public Transform doors;

    private void Start()
    {
        healthPoints = maxHealth;
        healthCounter.text = healthPoints.ToString();
    }

    public void TakeDamage(int damage)
    {
        healthPoints -= damage;
        healthCounter.text = healthPoints.ToString();

        if (healthPoints <= 0f)
        {
            houseManager.DestroyHouse(this);
        }
    }
}
