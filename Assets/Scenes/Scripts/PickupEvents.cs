using System;

public static class PickupEvents
{
    public static event Action<string> OnPickupCollected;

    public static void PickupCollected(string pickupName)
    {
        OnPickupCollected?.Invoke(pickupName);
    }
}