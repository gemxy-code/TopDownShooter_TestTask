using UnityEngine;

public class EnabledBonus : MonoBehaviour
{
    private IBonused _enabledBonus;
    private float _bonusTimer = 10f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IBonused bonus))
        {
            _enabledBonus = bonus;
            _enabledBonus.EnableBonus();
            Invoke(nameof(Rollback), _bonusTimer);
        }
    }

    private void Rollback()
    {
        _enabledBonus.DisableBonus();
    }
}
