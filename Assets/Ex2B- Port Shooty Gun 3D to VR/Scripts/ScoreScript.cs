using System;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    [SerializeField] private float comboBonus = 5f;
    private TextMeshProUGUI scoreText;
    private float comboTimer = 0f;
    private int score = 0;

    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        comboTimer += Time.deltaTime;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    public int GetScore()
    {
        return score;
    }
    
    public void AddScore()
    {
        float scoreIncrement = 1f + comboBonus / Mathf.Max(comboTimer, 0.1f);
        score += Mathf.RoundToInt(scoreIncrement);
        comboTimer = 0f;
        UpdateScoreText();
    }
}