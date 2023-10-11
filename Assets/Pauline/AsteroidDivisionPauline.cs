using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDivisionPauline : EnemyBaseClass
{

    [SerializeField] GameObject m_subAsteroids;
    AsteroidsSpawnerPauline m_spawner;
    [SerializeField] private int m_damages;

    internal override void TakeDamage(int m_damagePoints)
    {
        base.TakeDamage(m_damagePoints);
        if (m_lives <= 0)
        {
            m_spawner.UpdateAsteroidCount(-1);
                Destroy(gameObject);
            //Particles
            if (m_subAsteroids != null)
            {
                for (int i = 0; i < 2; i++)
                {
                    Instantiate(m_subAsteroids, transform.position, Quaternion.identity);
                }
            }
        }

    }

    public void SetSpawner(AsteroidsSpawnerPauline _spawner)
    {
        m_spawner = _spawner;
    }

    internal override int GetCollisionDamage()
    {
        return m_damages;
    }
}
