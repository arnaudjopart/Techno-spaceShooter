using System;
using UnityEngine;

namespace Mika
{
    public class Enemy : EnemyBaseClass
    {
        [SerializeField] private EnemyData enemyData;
        protected float lifeTime = 0f;
        public bool IsAlive { get => m_lives > 0 && this.lifeTime < this.enemyData.maxLifetime && this.gameObject.activeInHierarchy; }
        public event Action<int, int, int> EnemyLifeChangedEvent;

        private void Start()
        {
            ResetStates();
        }

        public string GetEnemyName()
        {
            return this.enemyData.enemyName;
        }

        internal override void TakeDamage(int m_damagePoints)
        {
            SoundManager.Instance.PlayChocClipAt(this.transform.position);

            int beforeHitLife = GetLives();
            base.TakeDamage(m_damagePoints);
            int lostLives = beforeHitLife - GetLives();
            if (lostLives > 0)
            {
                EnemyLifeChangedEvent?.Invoke(beforeHitLife, GetLives(), GetMaxLives());
                if (GetLives() <= 0)
                {
                    EventManager.InvokeEnemyDeathEvent(this);
                    gameObject.SetActive(false);
                }
            }
        }

        protected virtual void Update()
        {
            if (GetLives() <= 0)
            {
                return;
            }
            lifeTime += Time.deltaTime;
            if (lifeTime > this.enemyData.maxLifetime)
            {
                gameObject.SetActive(false);
            }
        }

        public void ResetStates()
        {
            this.lifeTime = 0f;
            EnemyLifeChangedEvent?.Invoke(GetLives(), (this.m_lives = Math.Max(1, GetMaxLives())), GetMaxLives());
        }

        public virtual int GetPointValue()
        {
            return this.enemyData.points;
        }

        public int GetMaxLives()
        {
            return this.enemyData.maxLives;
        }

        public int GetLives()
        {
            return this.m_lives;
        }
    }
}