using System.Collections;
using UnityEngine;

public class TakedGun : MonoBehaviour
{
    [SerializeField] private Transform _gunPosition;
    [SerializeField] private float _speedRotate;

    private bool _isRotate;
    private Gun _currentGun;

    private void OnEnable()
    {
        UserInput.OnMouseClicked += TakeShot;
        _isRotate = false;
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
            other.transform.rotation = _gunPosition.rotation;
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
        if(_isRotate)
        {
            StopCoroutine(nameof(RotateAndShoot));
            _isRotate = false;
        }
        StartCoroutine(nameof(RotateAndShoot), targetPosition);
    }

    private IEnumerator RotateAndShoot(Vector3 target)
    {
        _isRotate = true;
        Vector3 direction = (target - transform.forward).normalized;
        while(transform.forward != direction)
        {
            transform.Rotate(Vector3.up * _speedRotate * Time.deltaTime);
            yield return null;
        }
        if (_currentGun != null)
        {
            _currentGun.Shoot(target);
        }
        _isRotate = false;    
    }
}
