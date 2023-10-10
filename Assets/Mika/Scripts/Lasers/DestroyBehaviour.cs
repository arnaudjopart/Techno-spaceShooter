namespace Mika
{
    public class BehaviourDestroy : ProjectileLogicBaseClass
    {
        public override void ApplyEffect(Enemy _target)
        {
            Destroy(gameObject);
            _target.gameObject.SetActive(false);
        }
    }
}