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
        public event Action<int> ScoreUpdateEvent;
        public event Action<GameStates> GameStateChangedEvent;
        public GameStates GameState { get; private set; } = GameStates.INIT;
        [SerializeField] private GameObject explosionParticlePrefab;
        [Header("Level Settings")]
        [SerializeField] private float timeFactorByLevel = 0.1f;
        public int Level { get; private set; }
        public float TimeToSurvive { get; private set; }

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
            Time.timeScale = 1f;
            ResetLevel();
            ResetScore();
            StartLevel();
        }

        private void Update()
        {
            if (GameState == GameStates.STARTED && SpawnManager.Instance.IsSpawning)
            {
                TimeToSurvive -= Time.deltaTime;
                if (TimeToSurvive <= 0f)
                {
                    OnGameWon();
                }
            }
            // cheat mode "next level"
            if (Input.GetKeyDown(KeyCode.N))
            {
                OnGameWon();
            }
        }

        private void OnGameWon()
        {
            TimeToSurvive = 0f;
            SpawnManager.Instance.StopSpawn();
            var enemies = FindObjectsOfType<Enemy>();
            foreach (var e in enemies)
            {
                e.Die(false);
            }
            Level += 1;
            GameStateChangedEvent?.Invoke(GameState = GameStates.WIN);
        }

        private void StartLevel()
        {
            GameStateChangedEvent?.Invoke(GameState = GameStates.STARTED);
            TimeToSurvive = 30f * (1f + this.timeFactorByLevel * (Level - 1));
            SpawnManager.Instance.StartSpawn(Level);
        }

        public void OnEnemyDeath(Enemy enemy, bool withReward)
        {
            // affiche une explosion
            var o = Instantiate(this.explosionParticlePrefab, enemy.transform.position, Quaternion.identity);
            o.transform.SetParent(this.transform.parent);
            Destroy(o, 2f);
            // augmente le score
            if (withReward)
            {
                Score += enemy.GetPointValue();
                ScoreUpdateEvent?.Invoke(Score);
            }
        }

        public bool NextLevel()
        {
            if (GameState == GameStates.WIN)
            {
                StartLevel();
                return true;
            }
            return false;
        }

        public void ResetScore()
        {
            Score = 0;
            ScoreUpdateEvent?.Invoke(Score);
        }

        public void GameOver()
        {
            GameStateChangedEvent?.Invoke(GameState = GameStates.GAMEOVER);
            Time.timeScale = 0f;
        }

        public void ResetLevel()
        {
            Level = 1;
        }
    }
}
