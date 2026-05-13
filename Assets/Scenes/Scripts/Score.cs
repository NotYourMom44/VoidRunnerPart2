using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public GameObject player;
    public AudioSource scoreSFX;
    //public static int scoreCount;
   // public static int hiScoreCount;


    //ScoreManager ;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            scoreSFX.Play();

            ScoreManager.scoreCount += 1;
            ScoreManager.hiScoreCount += 1;

            Debug.Log("Obstacle Passed" + " | " + "Score: " + ScoreManager.scoreCount);
        }
    }



    // Update is called once per frame
    void Update()
    {

       // scoreText.text = "Score: " + scoreCount;
       // hiScoreText.text = "Hi-Score " + hiScoreCount;
    }
}
