using TMPro;
using UnityEngine;

namespace Mika
{
    public class Countdown : MonoBehaviour
    {
        private TMP_Text countdownText;

        private void Awake()
        {
            countdownText = GetComponent<TMP_Text>();
        }

        private void LateUpdate()
        {
            countdownText.text = SpawnManager.Instance.IsSpawning ? $"{Mathf.RoundToInt(GameManager.Instance.TimeToSurvive)}" : "";
        }
    }
}