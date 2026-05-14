using UnityEngine;
using TMPro;

public class FinalScoreDisplay : MonoBehaviour
{
    public TMP_Text finalScoreText;

    private void Start()
    {
        finalScoreText.text = "Final Score: " + ScoreManager.scoreCount;
    }
}
