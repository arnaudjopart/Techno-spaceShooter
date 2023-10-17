using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Mika
{
    [DefaultExecutionOrder(1000)]
    public class UIGameHandler : MonoBehaviour
    {
        [Header("Pannel Settings")]
        [SerializeField] private GameObject pauseMenu;
        [SerializeField] private KeyCode pauseKey = KeyCode.P;
        [SerializeField] private GameObject gameOverPanel;
        [SerializeField] private GameObject gameWonPanel;
        [Header("Lives Settings")]
        [SerializeField] private GameObject lostLives;
        [SerializeField] private GameObject leftLives;
        [Header("Score Settings")]
        [SerializeField] private TMP_Text scoreTxt;
        [Header("Weapon Settings")]
        [SerializeField] private Image weaponIcon;
        [SerializeField] private Color grayscaled;

        private void OnEnable()
        {
            GameManager.Instance.ScoreUpdateEvent += UpdateScore;
            GameManager.Instance.GameStateChangedEvent += OnGameOver;
            GameManager.Instance.GameStateChangedEvent += OnGameWon;
            EventManager.PlayerLifeChangedEvent += OnLifeChanged;
            EventManager.PlayerChangeWeaponEvent += OnPlayerWeaponChanged;
        }

        private void OnDisable()
        {
            GameManager.Instance.ScoreUpdateEvent -= UpdateScore;
            GameManager.Instance.GameStateChangedEvent -= OnGameOver;
            GameManager.Instance.GameStateChangedEvent -= OnGameWon;
            EventManager.PlayerLifeChangedEvent -= OnLifeChanged;
            EventManager.PlayerChangeWeaponEvent -= OnPlayerWeaponChanged;
        }

        private void Start()
        {
            this.leftLives.GetComponent<Image>().sprite = MainManager.Instance.ShipModel;
            Image image = this.lostLives.GetComponent<Image>();
            image.sprite = MainManager.Instance.ShipModel;
            image.color = grayscaled;
        }

        private void UpdateScore(int score)
        {
            this.scoreTxt.text = $"{score}";
        }

        private void OnGameOver(GameStates gameState)
        {
            if (gameState == GameStates.GAMEOVER)
            {
                this.gameOverPanel.SetActive(true);
            }
        }

        private void OnGameWon(GameStates gameState)
        {
            if (gameState == GameStates.WIN) {
                this.gameWonPanel.SetActive(true);
            }
        }

        public void NextLevel()
        {
            if (GameManager.Instance.NextLevel())
            {
                this.gameWonPanel.SetActive(false);
            }
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

        private void OnPlayerWeaponChanged(WeaponData weaponData)
        {
            this.weaponIcon.sprite = weaponData.icon;
            this.weaponIcon.color = weaponData.iconColor;
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