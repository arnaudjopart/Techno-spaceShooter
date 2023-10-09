public class BehaviourDestroy : ProjectileLogicBaseClass
{
    public override void ApplyEffect(EnemyBaseClass _target)
    {
        Destroy(this.gameObject);
        _target.gameObject.SetActive(false);
    }
}
