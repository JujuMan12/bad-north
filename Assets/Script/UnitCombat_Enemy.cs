using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCombat_Enemy : UnitCombat
{
    override public void Start()
    {
        base.Start();

        houseTarget = GameObject.FindGameObjectWithTag("House").GetComponent<HouseComponent>();
    }

    override public void SetNextTarget()
    {
        if (CanAttackUnit(unitTarget))
        {
            AtackTarget(true);
        }
        else if (houseTarget)
        {
            AtackTarget(false);
        }
    }
}
