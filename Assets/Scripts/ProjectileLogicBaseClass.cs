using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjectileLogicBaseClass : MonoBehaviour, IMovable
{
    [SerializeField] float m_speed;
    public float Speed => m_speed;

    public abstract void ApplyEffect(EnemyBaseClass _target);
}

