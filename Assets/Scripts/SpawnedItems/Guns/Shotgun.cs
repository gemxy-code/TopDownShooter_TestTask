using System.Collections;
using UnityEngine;

public class Shotgun :  Gun
{
    [SerializeField] private int _bulletCount;
    [SerializeField] private int _angleBetweenBullets;

    private float _currentAngle;

    public override void Shoot(Vector3 target)
    {
        if (IsCanShoot)
        {
            CalculateAngle();
            StartCoroutine(TakeCountBullet(target));
        }
    }

    private void CalculateAngle()
    {
        _currentAngle = ((_bulletCount / 2) * _angleBetweenBullets) * -1;
    }

    private IEnumerator TakeCountBullet(Vector3 target)
    {
        IsCanShoot = false;
        for(int i = 0; i < _bulletCount; i++)
        {
            GameObject newBullet = PoolManager.Instance.RentObject(_bullet);
            newBullet.transform.rotation = _bulletPosition.rotation;
            newBullet.transform.Rotate(0f, _currentAngle, 0f);
            newBullet.GetComponent<Bullet>().Init(_gunData, _bulletPosition, target);
            _currentAngle += _angleBetweenBullets;                 
        }
        yield return new WaitForSeconds(_timeToNextShoot);
        IsCanShoot = true;
    }
}
