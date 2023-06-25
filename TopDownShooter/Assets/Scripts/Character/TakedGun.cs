using UnityEngine;

public class TakedGun : MonoBehaviour
{
    private IShootable _currentGun;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IShootable takedGun))
        {
            TakeGun(takedGun);
        }
    }

    private void TakeGun(IShootable takedGun)
    {
        _currentGun = takedGun;
    }

    public void TakeShot()
    {
        if (_currentGun != null)
            _currentGun.Shoot();
    }
}
