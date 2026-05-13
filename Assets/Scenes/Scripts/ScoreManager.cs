using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI; // it tells the script to load UI elements

public class ScoreManager : MonoBehaviour
{

    public Text scoreText;
    public Text hiScoreText;
    public static int scoreCount;
    public static int hiScoreCount;
    //public int score;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            hiScoreCount = PlayerPrefs.GetInt("HiScore");
        }
    }


    // Update is called once per frame
    void Update()
    {

        if (scoreCount > hiScoreCount)
        {
            hiScoreCount = scoreCount ;
            PlayerPrefs.SetInt("HighScore", hiScoreCount);
        }

        scoreText.text = scoreCount.ToString();
        hiScoreText.text = hiScoreCount.ToString();
    }
}
