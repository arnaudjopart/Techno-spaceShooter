namespace Mika
{
    public class BehaviourDestroy : WeaponBase
    {
        public override void ApplyEffect(EnemyBaseClass _target)
        {
            this.gameObject.SetActive(false);
            _target.gameObject.SetActive(false);
        }
    }
}