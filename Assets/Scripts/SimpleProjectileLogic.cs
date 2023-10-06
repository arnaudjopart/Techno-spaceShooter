using UnityEngine;

public class SimpleProjectileLogic : ProjectileLogicBaseClass
{
    [SerializeField]private int m_damagePoints;

    public override void ApplyEffect(EnemyBaseClass _target)
    {
        _target.TakeDamage(m_damagePoints);
        Destroy(gameObject);
    }
}

