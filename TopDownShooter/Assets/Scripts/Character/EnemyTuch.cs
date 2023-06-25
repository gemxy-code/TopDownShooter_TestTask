using UnityEngine;

public class EnemyTuch : MonoBehaviour
{
    [SerializeField] private bool _isInvulnerability = false;

    private void OnEnable()
    {
        EventBus.OnInvulnerabilityEnabled += EnableInvulnerability;
        EventBus.OnInvulnerabilityDisabled += DisableInvulnerability;
    }

    private void OnDisable()
    {
        EventBus.OnInvulnerabilityEnabled -= EnableInvulnerability;
        EventBus.OnInvulnerabilityDisabled -= DisableInvulnerability;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out GameObject Enemy))
        {
            if(!_isInvulnerability)
            {
                EventBus.GameOver();
            }
        }
    }

    private void EnableInvulnerability() => _isInvulnerability = true;

    private void DisableInvulnerability() => _isInvulnerability = false;

}
