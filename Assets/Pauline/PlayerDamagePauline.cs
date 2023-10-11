using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamagePauline : EnemyBaseClass
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyBaseClass>() != null)
        {
            var dam = collision.GetComponent<EnemyBaseClass>().GetCollisionDamage();
            TakeDamage(dam);
        }
    }

    internal override void TakeDamage(int m_damagePoints)
    {
        base.TakeDamage(m_damagePoints);
        if (m_damagePoints <= 0) 
        {
            gameObject.SetActive(false);
            // particles
        }
    }




}
