using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]

public class ScoreManager : MonoBehaviour
{
    private TMP_Text scoreText; // Reference to the TextMeshPro Text object
    private int score = 0;

    private void Awake()
    {
        // Initialize the score text
        scoreText = GetComponent<TMP_Text>();
        UpdateScoreText();
    }
    // Call this method whenever you want to update the score
    public void IncreaseScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    // Update the TextMeshPro Text with the current score
    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }
}