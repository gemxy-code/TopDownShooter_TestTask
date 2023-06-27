using System;
using UnityEngine;

public class EventBus : MonoBehaviour
{
    public static event Action <float> OnSpeedBoosted;
    public static event Action <float> OnSpeedFalled;

    public static event Action OnInvulnerabilityEnabled;
    public static event Action OnInvulnerabilityDisabled;

    public static event Action <float> OnDamageTaked;
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

    public static void SendInvulnerabilityEnabled()
    {
        OnInvulnerabilityEnabled?.Invoke();
    }

    public static void SendInvulnerabilityDisabled()
    {
        OnInvulnerabilityDisabled?.Invoke();
    }
    public static void SendDamageTaked(float value)
    {
        OnDamageTaked?.Invoke(value);
    }

    public static void SendEnemyDied(int score)
    {
        OnEnemyDied?.Invoke(score);
    }

    public static void SendGunTaked(GameObject gun)
    {
        OnGunTaked?.Invoke(gun);
    }


    public static void GameOver()
    {
        //...
    }

}
