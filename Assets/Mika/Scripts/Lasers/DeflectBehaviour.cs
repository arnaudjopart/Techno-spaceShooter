using UnityEngine;

namespace Mika
{
    public class DeflectBehaviour : ProjectileLogicBaseClass
    {
        [SerializeField] private float reflectStrength;
        public override void ApplyEffect(EnemyBaseClass _target)
        {
            _target.GetComponent<Rigidbody2D>().AddForce(transform.up * reflectStrength, ForceMode2D.Impulse);
            Destroy(gameObject);
        }
    }
}