using UnityEngine;

//??
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 2;

    private Vector3 _startPoint;    
    private float _damage;
    private bool _isGrenade;
    private float _explosionRadius;
    private bool _isLimitedLife;
    private float _timeLife;
    private Vector3 _target;

    public void Init(Vector3 startPoint,  float damage, bool isGrenade, float explosionRadius, bool isLimitedLife, float timeLife, Vector3 target)
    {
        _startPoint = startPoint;
        _damage = damage;
        _isGrenade = isGrenade;
        _explosionRadius = explosionRadius;
        _isLimitedLife = isLimitedLife; 
        _timeLife = timeLife;
        _target = target;


        transform.position = startPoint;
        this.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (_isGrenade && transform.position == _target)
        {
            Collider[] collisions = Physics.OverlapSphere(transform.position, _explosionRadius);
            foreach (Collider enemy in collisions)
                enemy.GetComponent<TakeDamage>().TakedDamage(_damage);
            PoolManager.Instance.ReturnObject(this.gameObject);
        }
        else if (_isLimitedLife && Vector3.Distance(_startPoint, transform.position) >= _timeLife)
        {
            PoolManager.Instance.ReturnObject(this.gameObject);
        }
        else
        {
            transform.Translate(Vector3.forward * Time.deltaTime * _speed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_isGrenade && other.TryGetComponent(out TakeDamage enemy))
        {
            enemy.TakedDamage(_damage);
            PoolManager.Instance.ReturnObject(this.gameObject);
        }
    }
}
