using System;
using UnityEngine;

namespace Mika
{
    [RequireComponent(typeof(AudioSource))]
    public class Enemy : EnemyBaseClass
    {
        [SerializeField] private EnemyData enemyData;
        protected float lifeTime = 0f;
        public bool IsAlive { get => m_lives > 0 && this.lifeTime < this.enemyData.maxLifetime && this.gameObject.activeInHierarchy; }
        protected AudioSource audioSource;

        protected virtual void Awake()
        {
            this.audioSource = GetComponent<AudioSource>();
            ResetLife();
            ResetLifetime();
        }

        public string GetEnemyName()
        {
            return this.enemyData.enemyName;
        }

        internal override void TakeDamage(int m_damagePoints)
        {
            base.TakeDamage(m_damagePoints);
            if (m_lives <= 0)
            {
                EventManager.InvokeEnemyDeathEvent(this);
                gameObject.SetActive(false);
            }
        }

        protected virtual void Update()
        {
            if (m_lives <= 0)
            {
                return;
            }
            // désactivé après 5s
            lifeTime += Time.deltaTime;
            if (lifeTime > this.enemyData.maxLifetime)
            {
                gameObject.SetActive(false);
            }
        }

        public void ResetLifetime()
        {
            lifeTime = 0f;
        }

        public void ResetLife()
        {
            m_lives = Math.Max(1, this.enemyData.maxLives);
        }

        public virtual int GetPointValue()
        {
            return this.enemyData.points;
        }
    }
}