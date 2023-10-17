using System;
using UnityEngine;

namespace Mika
{
    public class Enemy : EnemyBaseClass
    {
        [SerializeField] private EnemyData enemyData;
        [SerializeField] private UnitUI unitUI;
        public float LifeTime { get; protected set; }
        public bool IsAlive => m_lives > 0 && LifeTime < this.enemyData.maxLifetime && this.gameObject.activeInHierarchy;
        public float lastHitTime;
        public bool IsMouseOver { get; private set; } = false;

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
            SoundManager.Instance.PlayChocClip();

            int beforeHitLife = GetLives();
            base.TakeDamage(m_damagePoints);
            int lostLives = beforeHitLife - GetLives();
            this.lastHitTime = Time.time;
            if (lostLives > 0)
            {
                if (GetLives() <= 0)
                {
                    Die(true);
                }
            }
        }

        public void Die(bool withReward)
        {
            EventManager.InvokeEnemyDeathEvent(this, withReward);
            gameObject.SetActive(false);
        }

        protected virtual void Update()
        {
            if (GetLives() <= 0)
            {
                return;
            }
            LifeTime += Time.deltaTime;
            if (LifeTime > this.enemyData.maxLifetime)
            {
                this.gameObject.SetActive(false);
                return;
            }
            if (!IsMouseOver)
            {
                if (this.lastHitTime + 1f > Time.time)
                {
                    EnableUnitUI();

                }
                else if (this.unitUI.gameObject.activeSelf)
                {
                    DisableUnitUI();
                }
            }
        }

        public void ResetStates()
        {
            LifeTime = 0f;
            lastHitTime = 0f;
            int maxLives = GetMaxLives();
            this.m_lives = Math.Max(1, maxLives);
            DisableUnitUI();
        }

        public virtual int GetPointValue()
        {
            return this.enemyData.points;
        }

        public int GetMaxLives()
        {
            return this.enemyData.maxLives + (GameManager.Instance != null ? GameManager.Instance.Level / 3 : 0);
        }

        public int GetLives()
        {
            return this.m_lives;
        }

        private void OnMouseEnter()
        {
            IsMouseOver = true;
            EnableUnitUI();
        }

        private void OnMouseExit()
        {
            IsMouseOver = false;
            DisableUnitUI();
        }

        private void EnableUnitUI()
        {
            this.unitUI.gameObject.SetActive(true);
            this.unitUI.UpdateLifeBar(GetLives(), GetMaxLives());
        }

        private void DisableUnitUI()
        {
            this.unitUI.gameObject.SetActive(false);
        }
    }
}