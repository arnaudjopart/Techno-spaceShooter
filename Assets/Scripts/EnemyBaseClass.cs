using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseClass : MonoBehaviour, IMovable
{
    [SerializeField] protected int m_lives;
    IEnumerator m_freezeCoroutine;
    [SerializeField] private float m_speed;

    public float Speed => m_speed;

    internal void FreezeForSeconds(float m_freezeTime)
    {
        m_freezeCoroutine = FreezeCoroutine(m_freezeTime);
        StartCoroutine(m_freezeCoroutine);
    }

    private IEnumerator FreezeCoroutine(float _freezeTime)
    {
        var currentSpeed = m_speed;
        m_speed = 0;
        yield return new WaitForSeconds(_freezeTime);
        m_speed = currentSpeed;
    }

    internal virtual void TakeDamage(int m_damagePoints)
    {
        m_lives -= m_damagePoints;
    }


}
