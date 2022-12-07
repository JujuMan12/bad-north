using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCombat_Player : UnitCombat
{
    override public void SetNextTarget()
    {
        base.SetNextTarget();

        if (!unitTarget)
        {
            unitMovement.squadController?.UpdateNavTarget();
        }
    }
}
