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

            Debug.Log("Obstacle Passed | Score: " + ScoreManager.scoreCount);
        }
    }
}