using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        [SerializeField] private GameObject lostLives;
        [SerializeField] private GameObject leftLives;
        [Header("Weapon Settings")]
        [SerializeField] private Sprite weaponSprite1; // TODO scriptable objects
        [SerializeField] private Sprite weaponSprite2;
        [SerializeField] private Image weaponIcon;

        private void OnEnable()
        {
            GameManager.Instance.OnScoreUpdateEvent += UpdateScore;
            EventManager.GameOverEvent += OnGameOver;
            EventManager.PlayerLostLifeEvent += OnLifeChanged;
            EventManager.PlayerChangeWeaponEvent += OnPlayerWeaponChanged;
        }

        private void OnDisable()
        {
            GameManager.Instance.OnScoreUpdateEvent -= UpdateScore;
            EventManager.GameOverEvent -= OnGameOver;
            EventManager.PlayerLostLifeEvent -= OnLifeChanged;
            EventManager.PlayerChangeWeaponEvent -= OnPlayerWeaponChanged;
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

        private void OnPlayerWeaponChanged(WeaponType type)
        {
            this.weaponIcon.sprite = type == WeaponType.LASER ? weaponSprite1 : weaponSprite2;
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