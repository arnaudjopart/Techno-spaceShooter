using UnityEngine;

public class DeflectBehaviour : ProjectileLogicBaseClass
{
    [SerializeField] private float reflectStrength;
    public override void ApplyEffect(EnemyBaseClass _target)
    {
        _target.GetComponent<Rigidbody2D>().AddForce(this.transform.up * this.reflectStrength, ForceMode2D.Impulse);
        Destroy(this.gameObject);
    }
}
