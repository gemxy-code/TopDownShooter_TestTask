using System.Collections;
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
            StartCoroutine(Rollback());
        }
    }

    private IEnumerator Rollback()
    {
        yield return new WaitForSeconds(_bonusTimer);
        _enabledBonus.DisableBonus();
        _enabledBonus = null;
    }
}
