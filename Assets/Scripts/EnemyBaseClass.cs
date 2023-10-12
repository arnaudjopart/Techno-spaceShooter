using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseClass : MonoBehaviour, IMovable
{
    [SerializeField] protected int m_lives;
    IEnumerator m_cachedCoroutine;
    [SerializeField] private float m_speed;

    public float Speed => m_speed;

    internal void FreezeForSeconds(float m_freezeTime)
    {
        m_cachedCoroutine = FreezeCoroutine(m_freezeTime);
        StartCoroutine(m_cachedCoroutine);
    }

    internal void ReduceSize()
    {
        transform.localScale = Vector3.one * .5f;
    }

    internal void ReduceSpeed(float _time, float _speedFactor)
    {
        m_cachedCoroutine = ReduceSpeedForSeconds(_time, _speedFactor);
        StartCoroutine(m_cachedCoroutine);
    }

    private IEnumerator FreezeCoroutine(float _freezeTime)
    {
        var currentSpeed = m_speed;
        m_speed = 0;
        yield return new WaitForSeconds(_freezeTime);
        m_speed = currentSpeed;
    }

    private IEnumerator ReduceSpeedForSeconds(float _freezeTime, float _speedFactor)
    {
        var currentSpeed = m_speed;
        m_speed *= _speedFactor;
        yield return new WaitForSeconds(_freezeTime);
        m_speed = currentSpeed;
    }

    internal virtual void TakeDamage(int m_damagePoints)
    {
        m_lives -= m_damagePoints;
    }

    internal virtual void ChangeDirection()
    {
        m_speed = -m_speed;
    }

    internal virtual int GetCollisionDamage()
    {
        return 0;
    }



}
