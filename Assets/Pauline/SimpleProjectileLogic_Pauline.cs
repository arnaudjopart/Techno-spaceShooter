using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleProjectileLogic_Pauline : ProjectileLogicBaseClass
{
    [SerializeField] private int m_damagePoints;

    public override void ApplyEffect(EnemyBaseClass _target)
    {
        _target.TakeDamage(m_damagePoints);
        _target.ChangeDirection();
        Destroy(gameObject);
    }

    
}
