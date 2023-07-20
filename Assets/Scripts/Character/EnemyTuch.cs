using UnityEngine;

public class EnemyTuch : MonoBehaviour
{
    [SerializeField] private bool _isInvulnerability = false;

    private void OnEnable()
    {
        EventBus.OnInvulnerabilityChange += ChangeInvulnerability;
    }

    private void OnDisable()
    {
        EventBus.OnInvulnerabilityChange -= ChangeInvulnerability;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out MoveToCharacter Enemy))
        {
            if(!_isInvulnerability)
            {
                EventBus.SendGameOver();
            }
        }
    }

    private void ChangeInvulnerability() => _isInvulnerability = !_isInvulnerability;

}
