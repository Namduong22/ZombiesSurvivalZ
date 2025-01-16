using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text highScoreText;
    [SerializeField] private int level;

    private void Awake()
    {
        if (scoreText == null || highScoreText == null)
        {
            Debug.LogError("ScoreText or HighScoreText is not assigned in the inspector");
        }
    }

    private void Start()
    {
        DisplayHighScore();
    }

    public void UpdateScore(ScoreController scoreController)
    {
        int currentScore = scoreController.Score;
        scoreText.text = $"Score: {currentScore}";

        int highScore = PlayerPrefs.GetInt(GetHighScoreKey(), 0);
        if (currentScore > highScore)
        {
            PlayerPrefs.SetInt(GetHighScoreKey(), currentScore);
            PlayerPrefs.Save();
        }

        DisplayHighScore();
    }

    public void DisplayHighScore()
    {
        int highScore = PlayerPrefs.GetInt(GetHighScoreKey(), 0);
        highScoreText.text = $"HighScore: {highScore}";
    }

    private string GetHighScoreKey()
    {
        return $"HighScore_Level{level}";
    }
}
