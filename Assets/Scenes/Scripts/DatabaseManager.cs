using UnityEngine;
using System.IO;

public class DatabaseManager : MonoBehaviour
{
    public static DatabaseManager Instance;

    private string savePath;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        savePath = Application.persistentDataPath + "/playerData.json";
    }

    public void SavePlayerData()
    {
        PlayerData data = new PlayerData(
            "Player",
            ScoreManager.scoreCount,
            ScoreManager.hiScoreCount,
            GameManager.Instance.levelsBeaten
        );

        string json = JsonUtility.ToJson(data, true);

        File.WriteAllText(savePath, json);

        Debug.Log("Player data saved");
    }

    public PlayerData LoadPlayerData()
    {
        if (!File.Exists(savePath))
        {
            Debug.Log("No save found");
            return null;
        }

        string json = File.ReadAllText(savePath);

        return JsonUtility.FromJson<PlayerData>(json);
    }
}