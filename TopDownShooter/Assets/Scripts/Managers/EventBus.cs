using System;
using UnityEngine;

public class EventBus : MonoBehaviour
{
    public static event Action <float> OnSpeedBoosted;
    public static event Action OnSpeedFalled;

    public static event Action OnInvulnerabilityEnabled;
    public static event Action OnInvulnerabilityDisabled;

    public static event Action OnGameOver;

    public static void SendSpeedBoosted(float value)
    {
        OnSpeedBoosted?.Invoke(value);
    }

    public static void SendSpeedFalled()
    {
        OnSpeedFalled?.Invoke();
    }

    public static void SendInvulnerabilityEnabled()
    {
        OnInvulnerabilityEnabled?.Invoke();
    }

    public static void SendInvulnerabilityDisabled()
    {
        OnInvulnerabilityDisabled?.Invoke();
    }

    public static void GameOver()
    {
        //...
    }

}
