using System;
using UnityEngine;

namespace Mika
{
    public class GameManager : MonoBehaviour
    {
        #region Singleton
        public static GameManager Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                Application.targetFrameRate = 60;
            }
            else if (Instance != this)
            {
                Destroy(this.gameObject);
                return;
            }
        }
        #endregion

        public int Score { get; private set; } = 0;
        public event Action<int> OnScoreUpdateEvent;
        [SerializeField] protected GameObject explosionParticlePrefab;

        private void OnEnable()
        {
            EventManager.EnemyDeathEvent += OnEnemyDeath;
        }

        private void OnDisable()
        {
            EventManager.EnemyDeathEvent -= OnEnemyDeath;
        }
  
        private void Start()
        {
            
            ResetScore();
        }

        public void OnEnemyDeath(Enemy enemy)
        {
            // affiche une explosion
            GameObject o = Instantiate(this.explosionParticlePrefab, enemy.transform.position, Quaternion.identity);
            o.transform.SetParent(this.transform);
            Destroy(o, 2f);
            // augmente le score
            Score += enemy.GetPointValue();
            OnScoreUpdateEvent?.Invoke(Score);
        }

        public void ResetScore()
        {
            Score = 0;
            OnScoreUpdateEvent?.Invoke(Score);
        }
    }
}
