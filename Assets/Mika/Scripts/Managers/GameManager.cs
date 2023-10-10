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



        private void OnEnable()
        {
            EventManager.EnemyDeathEvent += IncreaseScore;
        }

        private void OnDisable()
        {
            EventManager.EnemyDeathEvent -= IncreaseScore;
        }
  
        private void Start()
        {
            
            ResetScore();
        }

        public void IncreaseScore(Enemy enemy)
        {
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
