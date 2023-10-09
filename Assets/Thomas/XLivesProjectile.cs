using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XLivesProjectile : SimpleProjectileLogic
{
    [SerializeField] protected int m_projectileLives = 3;

    public override void ApplyEffect(EnemyBaseClass _target)
    {
        _target.GetComponent<EnemyBaseClass>().TakeDamage(m_damagePoints);
        m_projectileLives--;
        if (m_projectileLives == 0)
            Destroy(gameObject);
    }
}
