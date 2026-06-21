[System.Serializable]
public class PlayerData
{
    public string playerName;
    public int score;
    public int highScore;
    public int levelsBeaten;

    public PlayerData(string name, int score, int highScore, int levels)
    {
        playerName = name;
        this.score = score;
        this.highScore = highScore;
        levelsBeaten = levels;
    }
}