public class BehaviourDestroy : ProjectileLogicBaseClass
{
    public override void ApplyEffect(Enemy _target)
    {
        Destroy(this.gameObject);
        _target.gameObject.SetActive(false);
    }
}
