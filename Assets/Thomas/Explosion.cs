using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : SimpleProjectileLogic
{
    [HideInInspector] public float explosionDuration;
    [HideInInspector] public int explosionDamage;
    [HideInInspector] public float size;
    private Vector3 scaleModifier;
    private float sizeChangeStep;

    private IEnumerator Start()
    {
        scaleModifier = new Vector3((size - transform.localScale.x) / 5, (size - transform.localScale.y) / 5, 0);
        sizeChangeStep = explosionDuration / 11;
        yield return ChangeScale();
    }

    public override void ApplyEffect(EnemyBaseClass _target)
    {
        _target.GetComponent<EnemyBaseClass>().TakeDamage(explosionDamage);
    }

    IEnumerator ChangeScale()
    {
        for (int i = 0; i < 10; i++) 
        { 
            yield return new WaitForSeconds(sizeChangeStep);
            if (i == 5)
                scaleModifier = -scaleModifier;
            transform.localScale += scaleModifier;
        }
        yield return new WaitForSeconds(sizeChangeStep);
        Destroy(gameObject);
    }
}
