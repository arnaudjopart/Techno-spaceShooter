using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Mika
{
    [DefaultExecutionOrder(1000)]
    public class UIDisplayLevel : MonoBehaviour
    {
        [SerializeField] private TMP_Text levelTxt;
        [SerializeField] private Image levelBackground;
        private Animator anim;

        private void Awake()
        {
            this.anim = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            GameManager.Instance.GameStateChangedEvent += DisplayLevel;
        }

        private void OnDisable()
        {
            GameManager.Instance.GameStateChangedEvent -= DisplayLevel;
        }

        private void DisplayLevel(GameStates gameState)
        {
            if (gameState == GameStates.STARTED)
            {
                this.levelTxt.text = $"Level {GameManager.Instance.Level}";
                this.anim.SetTrigger("DisplayLevelTrigger");
            }
        }
    }
}