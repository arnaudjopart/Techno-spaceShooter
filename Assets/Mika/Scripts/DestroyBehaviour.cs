public class BehaviourDestroy : ProjectileLogicBaseClass
{
    public override void ApplyEffect(EnemyBaseClass _target)
    {
        Destroy(this.gameObject);
        Destroy(_target.gameObject);
    }
}
