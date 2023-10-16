using UnityEngine;

namespace Mika
{
    public class DeflectBehaviour : WeaponBase
    {
        [SerializeField] private float reflectStrength;
        public override void ApplyEffect(EnemyBaseClass _target)
        {
            _target.GetComponent<Rigidbody2D>().AddForce(transform.up * reflectStrength, ForceMode2D.Impulse);
            this.gameObject.SetActive(false);
        }
    }
}