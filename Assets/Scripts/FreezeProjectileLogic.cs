public class FreezeProjectileLogic : ProjectileLogicBaseClass
{
    public float m_freezeTime;
    public override void ApplyEffect(EnemyBaseClass _target)
    {
        _target.FreezeForSeconds(m_freezeTime);
        Destroy(gameObject);
    }
}

