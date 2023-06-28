using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] protected GameObject _bullet;
    [SerializeField] protected Transform _bulletPosition;
    [SerializeField] protected GunData _gunData;

    public bool IsCanShoot;
    protected float _timeToNextShoot;

    private void Awake()
    {
        IsCanShoot = true;
        _timeToNextShoot = 1 / _gunData.ShootSpeed;
    }

    public virtual void Shoot(Vector3 target)
    {
        if (IsCanShoot)
        {
            StartCoroutine(TakeOneBullet(target));
        }
    }

    private IEnumerator TakeOneBullet(Vector3 target)
    {
        IsCanShoot = false;
        GameObject newBullet = PoolManager.Instance.RentObject(_bullet);
        newBullet.GetComponent<Bullet>().Init(_gunData, _bulletPosition, target);
        yield return new WaitForSeconds(_timeToNextShoot);
        IsCanShoot = true;
    }
}
