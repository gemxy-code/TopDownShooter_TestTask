using System.Collections;
using System.Drawing;
using UnityEngine;
using UnityEngine.UIElements;

public class TakedGun : MonoBehaviour
{
    [SerializeField] private Transform _gunPosition;
    [SerializeField] private float _speedRotate;

    private Gun _currentGun;
    //private bool _isNowRotate;


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
            TakeGun(takedGun);            
        }
    }

    private void TakeGun(Gun takedGun)
    {
        _currentGun = takedGun;
    }

    public void TakeShot(Vector3 targetPosition)
    {
        //for debug
        if (_currentGun != null)
        {
            _currentGun.Shoot(targetPosition);
        }
    }

        /* Bugs
        if (_isNowRotate)
        {
            StopCoroutine(nameof(RotateAndShoot));
            _isNowRotate = false;
        }
        StartCoroutine(RotateAndShoot(targetPosition));
    }

    private IEnumerator RotateAndShoot(Vector3 targetPosition)
    {
        Vector3 direction = (targetPosition - transform.position).normalized;
        direction.y = 0f;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(direction), _speedRotate * Time.deltaTime);
        if(_currentGun != null)
        {
            _currentGun.Shoot(targetPosition);
        }
        _isNowRotate = false;
    }
        */
}
