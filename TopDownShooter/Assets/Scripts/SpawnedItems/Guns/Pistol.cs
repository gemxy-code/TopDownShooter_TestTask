using System.Collections;
using UnityEngine;

public class Pistol : Gun
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _bulletPosition;
    [SerializeField] private float _shootSpeed = 0.5f;

    [SerializeField] private float _damage = 3;

    private bool _isCanShoot;

    private void Awake()
    {
        _isCanShoot = true;
    }


    public override void Shoot(Vector3 target)
    {
        if( _isCanShoot )
        {
            StartCoroutine(TakeOneBullet(target));
        }
    }

    private IEnumerator TakeOneBullet(Vector3 target)
    {
        _isCanShoot = false;
        GameObject newBullet = PoolManager.Instance.RentObject(_bullet);
        newBullet.GetComponent<Bullet>().Init(_bulletPosition.position, _damage, false, 0,  false, 0f, target);
        yield return new WaitForSeconds(_shootSpeed);
        _isCanShoot = true;
    }
}
