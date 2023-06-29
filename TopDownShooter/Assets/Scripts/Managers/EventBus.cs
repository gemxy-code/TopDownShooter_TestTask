using System;
using UnityEngine;

public class EventBus : MonoBehaviour
{
    //Enable/Disable speed Power up
    public static event Action <float> OnSpeedBoosted;
    public static event Action <float> OnSpeedFalled;

    //Enable/Disable invulnerability Power up
    public static event Action OnInvulnerabilityChange;

    public static event Action <int> OnEnemyDied;

    public static event Action <GameObject> OnGunTaked;

    public static event Action OnGameOver;

    public static void SendSpeedBoosted(float value)
    {
        OnSpeedBoosted?.Invoke(value);
    }

    public static void SendSpeedFalled(float value)
    {
        OnSpeedFalled?.Invoke(value);
    }

    public static void SendInvulnerabilityChange()
    {
        OnInvulnerabilityChange?.Invoke();
    }

    public static void SendEnemyDied(int score)
    {
        OnEnemyDied?.Invoke(score);
    }

    public static void SendGunTaked(GameObject gun)
    {
        OnGunTaked?.Invoke(gun);
    }

    public static void SendGameOver()
    {
        OnGameOver?.Invoke();
    }
}
