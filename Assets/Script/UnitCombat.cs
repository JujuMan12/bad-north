using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCombat : MonoBehaviour
{
    [HideInInspector] private int healthPoints;
    [HideInInspector] public UnitComponent unitComponent;
    [HideInInspector] protected UnitCombat unitTarget;
    [HideInInspector] protected HouseComponent houseTarget;
    [HideInInspector] private float timeToHit;

    [Header("Targeting")]
    [SerializeField] private string opponentTag = "EnemyUnit";
    [SerializeField] private float attackDistance = 1f;

    [Header("Stats")]
    [SerializeField] private int maxHealth = 5;
    [SerializeField] private TMPro.TextMeshPro healthCounter;
    [SerializeField] private int damageMin = 1;
    [SerializeField] private int damageMax = 3;
    [SerializeField] private float hitCooldown = 1f;

    virtual public void Start()
    {
        healthPoints = maxHealth;
        healthCounter.text = healthPoints.ToString();
    }

    private void FixedUpdate()
    {
        if (timeToHit > 0f)
        {
            timeToHit -= Time.deltaTime;
        }

        SetNextTarget();
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.CompareTag(opponentTag) && !unitTarget)
        {
            unitTarget = collider.GetComponent<UnitCombat>();
        }
    }

    virtual public void SetNextTarget()
    {
        if (CanAttackUnit(unitTarget))
        {
            AtackTarget(true);
        }
    }

    protected void AtackTarget(bool targetIsUnit)
    {
        Transform target = targetIsUnit ? unitTarget.transform : houseTarget.doors;

        if (CanHitTarget(target))
        {
            unitComponent.unitMovement.SetNavTarget(transform);
            if (timeToHit <= 0f)
            {
                HitTarget(targetIsUnit);
            }
        }
        else
        {
            unitComponent.unitMovement.SetNavTarget(target);
        }
    }

    private void HitTarget(bool targetIsUnit)
    {
        int damage = Random.Range(damageMin, damageMax + 1);

        if (targetIsUnit)
        {
            unitTarget.TakeDamage(damage);
        }
        else
        {
            houseTarget.TakeDamage(damage);
        }

        timeToHit = hitCooldown;
    }

    public void TakeDamage(int damage)
    {
        healthPoints -= damage;
        healthCounter.text = healthPoints.ToString();

        if (healthPoints <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    protected bool CanAttackUnit(UnitCombat unit)
    {
        return unitTarget && unitTarget.enabled;
    }

    private bool CanHitTarget(Transform target)
    {
        return Vector3.Distance(transform.position, target.position) <= attackDistance;
    }
}
