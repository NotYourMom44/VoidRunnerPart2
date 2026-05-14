using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text hiScoreText;

    public static int scoreCount;
    public static int hiScoreCount;

    void Start()
    {
        scoreCount = 0;

        if (PlayerPrefs.HasKey("HighScore"))
        {
            hiScoreCount = PlayerPrefs.GetInt("HighScore");
        }
    }

    void Update()
    {
        if (scoreCount > hiScoreCount)
        {
            hiScoreCount = scoreCount;
            PlayerPrefs.SetInt("HighScore", hiScoreCount);
        }

        scoreText.text = "Score: " + scoreCount;
        hiScoreText.text = "High Score: " + hiScoreCount;
    }
}
