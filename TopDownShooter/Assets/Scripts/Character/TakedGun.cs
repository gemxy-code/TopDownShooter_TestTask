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
            EventBus.SendGunTaked(other.gameObject);
            TakeGun(takedGun);
            other.gameObject.transform.SetParent(_gunPosition);
            other.transform.position  = _gunPosition.position; 
            other.transform.rotation = _gunPosition.rotation;
            
            takedGun.IsCanShoot = true;        
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


    private IEnumerator RotateAndShoot(Vector3 targetPosition)
    {
        _isRotate = true;
        Vector3 direction = (targetPosition - transform.position).normalized;
        direction.y = 0f;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(direction), _speedRotate * Time.deltaTime);
        yield return null;
        if (_currentGun != null)
        {
            _currentGun.Shoot(targetPosition);
        }
        _isRotate = false;    
    }
}
