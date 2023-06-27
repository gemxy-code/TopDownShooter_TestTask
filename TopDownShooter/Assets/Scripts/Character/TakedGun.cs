using UnityEngine;

public class TakedGun : MonoBehaviour
{
    [SerializeField] private Transform _gunPosition;

    private Gun _currentGun;

    private void OnEnable()
    {
        UserInput.OnMouseClicked += TakeShot;
    }

    private void OnDisable()
    {
        UserInput.OnMouseClicked -= TakeShot;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Gun takedGun))
        {
            other.gameObject.transform.SetParent(_gunPosition);
            other.transform.position  = _gunPosition.position;
            EventBus.SendGunTaked(other.gameObject);
            takedGun.IsCanShoot = true;
            TakeGun(takedGun);            
        }
    }

    private void TakeGun(Gun takedGun)
    {
        _currentGun = takedGun;
    }

    public void TakeShot(Vector3 targetPosition)
    {
        if (_currentGun != null)
        {
            _currentGun.Shoot(targetPosition);
        }
    }
}
