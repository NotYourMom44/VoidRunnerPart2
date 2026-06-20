using UnityEngine;

public class Score : MonoBehaviour
{
    public AudioSource scoreSFX;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            if (scoreSFX != null)
            {
                scoreSFX.Play();
            }

            ScoreManager.AddScore(1);

            GameEvents.ObstaclePassed();

            Debug.Log("Obstacle Passed | Score: " + ScoreManager.scoreCount);
        }
    }
}