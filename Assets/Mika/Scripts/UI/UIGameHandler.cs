using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Mika
{
    [DefaultExecutionOrder(1000)]
    public class UIGameHandler : MonoBehaviour
    {
        [Header("Pause Settings")]
        [SerializeField] private GameObject pauseMenu;
        [SerializeField] private KeyCode pauseKey = KeyCode.P;
        [Header("Score Settings")]
        [SerializeField] private TMP_Text scoreTxt;
        [Header("Game Over Settings")]
        [SerializeField] private GameObject gameOverPanel;
        [Header("Lives Settings")]
        [SerializeField] private GameObject lostLives, leftLives;

        private void OnEnable()
        {
            GameManager.Instance.OnScoreUpdateEvent += UpdateScore;
            EventManager.GameOverEvent += OnGameOver;
            EventManager.PlayerLostLifeEvent += OnLifeChanged;
        }

        private void OnDisable()
        {
            GameManager.Instance.OnScoreUpdateEvent -= UpdateScore;
            EventManager.GameOverEvent -= OnGameOver;
            EventManager.PlayerLostLifeEvent -= OnLifeChanged;
        }

        private void UpdateScore(int score)
        {
            scoreTxt.text = $"{score}";
        }

        private void OnGameOver()
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0f;
        }

        private void OnLifeChanged(int oldLife, int newLife, int maxLife)
        {
            RectTransform rect = this.lostLives.GetComponent<RectTransform>();
            Vector2 sizeDelta = rect.sizeDelta;
            sizeDelta.x = 112f * (maxLife - newLife);
            rect.sizeDelta = sizeDelta;
            rect = this.leftLives.GetComponent<RectTransform>();
            sizeDelta = rect.sizeDelta;
            sizeDelta.x = 112f * newLife;
            rect.sizeDelta = sizeDelta;
        }

        private void Update()
        {
            if (Input.GetKeyDown(pauseKey))
            {
                if (!pauseMenu.activeInHierarchy)
                {
                    pauseMenu.SetActive(true);
                    Time.timeScale = 0f;
                }
                else
                {
                    pauseMenu.SetActive(false);
                    Time.timeScale = 1f;
                }
            }
        }

        public void RestartGame()
        {
            SceneManager.LoadScene("MikaInput_Scene");
        }

        public void BackToMainMenu()
        {
            SceneManager.LoadScene("MikaMainMenu_Scene");
        }
    }
}