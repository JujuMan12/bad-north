using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCombat : MonoBehaviour
{
    [HideInInspector] private int healthPoints;
    [HideInInspector] protected UnitCombat unitTarget;
    [HideInInspector] private float timeToHit;

    [Header("Targeting")]
    [SerializeField] protected UnitMovement unitMovement;
    [SerializeField] private string opponentTag = "EnemyUnit";
    [SerializeField] private float attackDistance = 2f;

    [Header("Stats")]
    [SerializeField] private int maxHealth = 5;
    [SerializeField] private int damageMin = 1;
    [SerializeField] private int damageMax = 3;
    [SerializeField] private float hitCooldown = 1f;

    private void Start()
    {
        healthPoints = maxHealth;
    }

    private void FixedUpdate()
    {
        if (timeToHit > 0f)
        {
            timeToHit -= Time.deltaTime;
        }

        SetNextTarget();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag(opponentTag) && !unitTarget)
        {
            unitTarget = collider.GetComponent<UnitCombat>();
        }
    }

    virtual public void SetNextTarget()
    {
        if (unitTarget)
        {
            AtackTarget();
        }
    }

    private void AtackTarget()
    {
        if (CanHitTarget())
        {
            unitMovement.navTarget = transform;
            if (timeToHit <= 0f)
            {
                HitTarget();
            }
        }
        else
        {
            unitMovement.navTarget = unitTarget.transform;
        }
    }

    private void HitTarget()
    {
        int damage = Random.Range(damageMin, damageMax + 1);
        unitTarget.TakeDamage(damage);

        timeToHit = hitCooldown;
    }

    public void TakeDamage(int damage)
    {
        healthPoints -= damage;

        if (healthPoints <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private bool CanHitTarget()
    {
        return Vector3.Distance(transform.position, unitTarget.transform.position) <= attackDistance;
    }
}
