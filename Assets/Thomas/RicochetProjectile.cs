using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RicochetProjectile : XLivesProjectile
{
    public override void ApplyEffect(EnemyBaseClass _target)
    {
        base.ApplyEffect(_target);
        if (gameObject.TryGetComponent<SimpleUpMovement>(out SimpleUpMovement componentUp))
        {
            gameObject.AddComponent<SimpleDownMovement>();
            Component.Destroy(componentUp);
        }
        else if (gameObject.TryGetComponent<SimpleDownMovement>(out SimpleDownMovement componentDown))
        {
            gameObject.AddComponent<SimpleUpMovement>();
            Component.Destroy(componentDown);
        }
    }
}
