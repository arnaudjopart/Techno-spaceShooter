namespace Mika
{
    public class BehaviourDestroy : ProjectileLogicBaseClass
    {
        public override void ApplyEffect(EnemyBaseClass _target)
        {
            Destroy(gameObject);
            _target.gameObject.SetActive(false);
        }
    }
}