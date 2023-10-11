using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDivisionPauline : EnemyBaseClass
{

    [SerializeField] GameObject[] m_subAsteroids;
    internal override void TakeDamage(int m_damagePoints)
    {
        base.TakeDamage(m_damagePoints);
        if (m_lives <= 0)
        {
            Destroy(gameObject);
            //Particles
            if(m_subAsteroids != null)
            {
                Instantiate(m_subAsteroids[Random.Range(0, m_subAsteroids.Length)]);
            }         
        }

    }
}
