using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int pickupsCollected;
    public int obstaclesPassed;
    public int levelsBeaten;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        PickupEvents.OnPickupCollected += HandlePickupCollected;

        GameEvents.OnObstaclePassed += HandleObstaclePassed;

        GameEvents.OnBossSpawned += HandleBossSpawned;
        GameEvents.OnBossBeaten += HandleBossBeaten;
    }

    private void OnDisable()
    {
        PickupEvents.OnPickupCollected -= HandlePickupCollected;

        GameEvents.OnObstaclePassed -= HandleObstaclePassed;

        GameEvents.OnBossSpawned -= HandleBossSpawned;
        GameEvents.OnBossBeaten -= HandleBossBeaten;
    }

    private void HandlePickupCollected(string pickupName)
    {
        pickupsCollected++;
        Debug.Log("GameManager heard pickup event: " + pickupName);
    }

    private void HandleObstaclePassed()
    {
        obstaclesPassed++;
        Debug.Log("GameManager heard obstacle event. Obstacles passed: " + obstaclesPassed);
    }

    private void HandleBossSpawned()
    {
        Debug.Log("GameManager heard boss spawned event");
    }

    private void HandleBossBeaten()
    {
        levelsBeaten++;

        Debug.Log("Level completed. Levels beaten: " + levelsBeaten);
    }
}