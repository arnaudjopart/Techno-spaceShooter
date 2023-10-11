using UnityEngine;

namespace Mika
{
    public class SimpleProjectileNoDestroy : ProjectileLogicBaseClass
    {
        [SerializeField] protected int m_damagePoints;

        public override void ApplyEffect(EnemyBaseClass _target)
        {
            _target.GetComponent<EnemyBaseClass>().TakeDamage(m_damagePoints);
        }
    }
}