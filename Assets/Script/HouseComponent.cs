using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseComponent : MonoBehaviour
{
    [HideInInspector] private int healthPoints;
    [HideInInspector] public HouseManager houseManager;

    [Header("House")]
    [SerializeField] private int maxHealth = 100;
    [SerializeField] public Transform doors;

    private void Start()
    {
        healthPoints = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        healthPoints -= damage;

        if (healthPoints <= 0f)
        {
            houseManager.DestroyHouse(this);
        }
    }
}
