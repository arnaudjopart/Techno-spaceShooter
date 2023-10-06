using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DividingProjectile : SimpleProjectileLogic
{
    [SerializeField] GameObject m_leftProjectilePrefab;
    [SerializeField] GameObject m_rightProjectilePrefab;

    public override void ApplyEffect(EnemyBaseClass _target)
    {
        GameObject leftProjectile = GameObject.Instantiate(m_leftProjectilePrefab, new Vector2(_target.transform.position.x, _target.transform.position.y), Quaternion.Euler(Vector3.forward * 270));
        GameObject rightProjectile = GameObject.Instantiate(m_rightProjectilePrefab, new Vector2(_target.transform.position.x, _target.transform.position.y), Quaternion.Euler(Vector3.forward * 90));
        base.ApplyEffect(_target);
    }
}
