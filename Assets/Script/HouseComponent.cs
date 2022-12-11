using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseComponent : MonoBehaviour
{
    [HideInInspector] private int currentHealth;

    [Header("Stats")]
    [SerializeField] private int maxHealth = 100;

    private void Start()
    {
        currentHealth = maxHealth;
    }
}
