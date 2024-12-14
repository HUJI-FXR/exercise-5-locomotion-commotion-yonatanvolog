using UnityEngine;
using TMPro;

public class HighScoreScript : MonoBehaviour
{
    private TextMeshProUGUI highScoreText;
    private ScoreScript scoreScript;

    private int highScore;
    
    private void Awake()
    {
        highScoreText = GetComponent<TextMeshProUGUI>();
        scoreScript = FindObjectOfType<ScoreScript>();
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore");
        }
        else
        {
            highScore = 0;
        }

        UpdateHighScoreText();
    }

    public void CheckAndSaveHighScore()
    {
        int currentScore = scoreScript.GetScore();
        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore);
        }

        UpdateHighScoreText();
    }

    private void UpdateHighScoreText()
    {
        highScoreText.text = "High Score: " + highScore;
    }
}