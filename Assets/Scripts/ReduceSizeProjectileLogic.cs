using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReduceSizeProjectileLogic : ProjectileLogicBaseClass
{
    public override void ApplyEffect(EnemyBaseClass _target)
    {
        _target.ReduceSize();
    }
}
