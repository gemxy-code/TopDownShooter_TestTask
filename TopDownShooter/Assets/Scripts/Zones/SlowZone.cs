using UnityEngine;

public class SlowZone : Zone
{
    [SerializeField] private float _speedSlowdown;

    protected override void Activate()
    {
        EventBus.SendSpeedBoosted(_speedSlowdown);
    }

    private void Deactivate()
    {
        EventBus.SendSpeedFalled(_speedSlowdown);
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent(out CharacterMovement character))
        {
            Deactivate();
        }
    }
}
