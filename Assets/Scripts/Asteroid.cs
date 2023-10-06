using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : EnemyBaseClass
{
    GameObject[] m_subAsteroids;
    internal override void TakeDamage(int m_damagePoints)
    {
        base.TakeDamage(m_damagePoints);
        if(m_lives<=0)Destroy(gameObject);
        //Instantiate sub asteroids;
    }
}
