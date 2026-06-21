using UnityEngine;
using TMPro;

public class MetricsDisplay : MonoBehaviour
{
    public TMP_Text metricsText;

    void Start()
    {
        PlayerData data = DatabaseManager.Instance.LoadPlayerData();

        if (data != null)
        {
            metricsText.text =
                "Player: " + data.playerName +
                "\nScore: " + data.score +
                "\nHigh Score: " + data.highScore +
                "\nLevels Beaten: " + data.levelsBeaten;
        }
        else
        {
            metricsText.text = "No player data found";
        }
    }
}