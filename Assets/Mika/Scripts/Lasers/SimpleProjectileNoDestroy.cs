using UnityEngine;

public class SimpleProjectileNoDestroy : ProjectileLogicBaseClass
{
    [SerializeField] protected int m_damagePoints;

    public override void ApplyEffect(Enemy _target)
    {
        _target.GetComponent<Enemy>().TakeDamage(m_damagePoints);
    }
}
