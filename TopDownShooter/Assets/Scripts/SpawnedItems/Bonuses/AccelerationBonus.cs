using UnityEngine;

public class AccelerationBonus : MonoBehaviour, IBonused
{
    [SerializeField] private float _boostSpeedValue;

    public void EnableBonus() 
    {
        EventBus.SendSpeedBoosted(_boostSpeedValue);
    }
    public void DisableBonus()
    {
        EventBus.SendSpeedFalled(_boostSpeedValue);
    } 
}
