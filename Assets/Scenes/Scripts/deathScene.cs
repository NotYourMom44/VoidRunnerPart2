using UnityEngine;
using UnityEngine.SceneManagement;

public class deathScene : MonoBehaviour
{
    public void restartScene()
    {
        Debug.Log("Restart button clicked");
        ScoreManager.scoreCount = 0;
        SceneManager.LoadScene("SampleScene");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            restartScene();
        }
    }

    public void BackToMainMenu()
    {
        ScoreManager.scoreCount = 0;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu");
    }
}
