using UnityEngine;

//Relised for every bullet own behavior and inject to gun with ScriptableObject
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 2;

    private GunData _gunData;
    private Vector3 _target;
    private Transform _startPoint;

    public void Init(GunData data, Transform startPoint, Vector3 target)
    {
        _gunData = data;
        _startPoint = startPoint;
        transform.position = _startPoint.position;
        transform.rotation = _startPoint.rotation;
        _target = target;

        gameObject.SetActive(true);
    }

    private void Update()
    {
        if (_gunData.IsGrenade && transform.position == _target)
        {
            Collider[] collisions = Physics.OverlapSphere(transform.position, _gunData.ExplosionRadius);
            foreach (Collider Object in collisions)
                if(Object.TryGetComponent(out TakeDamage enemy))
                {
                    enemy.TakedDamage(_gunData.Damage);
                }
            PoolManager.Instance.ReturnObject(this.gameObject);
        }
        else if ((_gunData.IsLimitedLife && Vector3.Distance(_startPoint.position, transform.position) >= _gunData.TimeLife)||(transform.position.x > WorldLimit.MapBorders.x || transform.position.x < -WorldLimit.MapBorders.x || transform.position.z > WorldLimit.MapBorders.z || transform.position.z < -WorldLimit.MapBorders.z))
        {
            PoolManager.Instance.ReturnObject(this.gameObject);
        }
        else if(_gunData.IsGrenade)
        {
            transform.LookAt(_target);
            transform.Translate(Vector3.forward * Time.deltaTime * _speed);
        }
        else
        {
            transform.Translate(Vector3.forward * Time.deltaTime * _speed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_gunData.IsGrenade && other.TryGetComponent(out TakeDamage enemy))
        {
            enemy.TakedDamage(_gunData.Damage);
            PoolManager.Instance.ReturnObject(this.gameObject);
        }
    }
}
