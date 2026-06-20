using System;

public static class GameEvents
{
    public static event Action OnObstaclePassed;
    public static event Action OnBossSpawned;
    public static event Action OnBossBeaten;

    public static void ObstaclePassed()
    {
        OnObstaclePassed?.Invoke();
    }

    public static void BossSpawned()
    {
        OnBossSpawned?.Invoke();
    }

    public static void BossBeaten()
    {
        OnBossBeaten?.Invoke();
    }
}