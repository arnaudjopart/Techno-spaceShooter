using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingProjectile : SimpleProjectileLogic
{
    [SerializeField] GameObject ExplosionPrefab;
    [SerializeField] float m_explosionDuration;
    [SerializeField] float m_explosionMaxSize;

    public override void ApplyEffect(EnemyBaseClass _target)
    {
        GameObject explosion = GameObject.Instantiate(ExplosionPrefab, _target.transform.position, new Quaternion(0, 0, 0, 0));
        Explosion script = explosion.GetComponent<Explosion>();
        script.explosionDuration = m_explosionDuration;
        script.explosionDamage = m_damagePoints;
        script.size = m_explosionMaxSize;
        Destroy(gameObject);
    }
}
