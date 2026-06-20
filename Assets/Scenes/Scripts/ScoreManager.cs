using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text hiScoreText;

    public static int scoreCount;
    public static int hiScoreCount;

    private const string HighScoreKey = "HighScore";

    void Start()
    {
        scoreCount = 0;
        hiScoreCount = PlayerPrefs.GetInt(HighScoreKey, 0);
        UpdateUI();
    }

    void Update()
    {
        UpdateUI();
    }

    public static void AddScore(int amount)
    {
        scoreCount += amount;

        if (scoreCount > hiScoreCount)
        {
            hiScoreCount = scoreCount;
            PlayerPrefs.SetInt(HighScoreKey, hiScoreCount);
            PlayerPrefs.Save();
        }
    }

    private void UpdateUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + scoreCount;
        }

        if (hiScoreText != null)
        {
            hiScoreText.text = "High Score: " + hiScoreCount;
        }
    }
}