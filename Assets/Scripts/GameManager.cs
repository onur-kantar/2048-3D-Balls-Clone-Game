using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text totalScoreText;
    [SerializeField] GameObject gameOver;
    public bool isGameOver;
    int totalScore;
    private void Start()
    {
        isGameOver = false;
        Time.timeScale = 1;
        totalScore = 0;
    }
    public void IncreasesScore()
    {
        totalScore++;
        totalScoreText.text = Constants.SCORE_TEXT + totalScore.ToString();
    }
    public void HasViolation(float yAxis)
    {
        if (yAxis > Constants.VIOLATION_LIMIT)
        {
            GameOver();
        }
    }
    public void GameOver()
    {
        Time.timeScale = 0;
        isGameOver = true;
        gameOver.SetActive(true);
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
