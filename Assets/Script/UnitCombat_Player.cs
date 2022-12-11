using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCombat_Player : UnitCombat
{
    override public void SetNextTarget()
    {
        if (CanAttackUnit(unitTarget))
        {
            AtackTarget(true);
        }
        else
        {
            unitComponent?.squadController?.UpdateNavTarget();
        }
    }
}
