using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : SimpleProjectileLogic
{
    private float timer;
    [HideInInspector] public float explosionDuration;
    public int m_explosionDamage;

    public void Start()
    {
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= explosionDuration)
            Destroy(gameObject);
    }

    public override void ApplyEffect(EnemyBaseClass _target)
    {
        _target.GetComponent<EnemyBaseClass>().TakeDamage(m_explosionDamage);
    }
}
