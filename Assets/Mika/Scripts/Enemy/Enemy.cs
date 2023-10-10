using UnityEngine;

namespace Mika
{
    public class Enemy : EnemyBaseClass
    {
        [SerializeField] private float maxLifeTime = 20f;
        private float lifeTime = 0f;
        [Range(1, 100)]
        [SerializeField] private int points = 1;

        private void Start()
        {
            m_lives = Mathf.Max(1, m_lives);
            lifeTime = 0f;
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

        private void Update()
        {
            if (m_lives <= 0)
            {
                return;
            }
            // désactivé après 5s
            lifeTime += Time.deltaTime;
            if (lifeTime > maxLifeTime)
            {
                gameObject.SetActive(false);
            }
        }

        public void ResetLifetime()
        {
            lifeTime = 0f;
        }

        public virtual int GetPointValue()
        {
            return points;
        }
    }
}