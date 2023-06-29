using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 20;

    private GunData _gunData;
    private Vector3 _target;
    private Transform _startPoint;
    private bool _isStopGame;

    private void Awake()
    {
        _isStopGame = false;
    }

    private void OnEnable() => EventBus.OnGameOver += GameOverStopGame;
    private void OnDisable() => EventBus.OnGameOver -= GameOverStopGame;

    public void Init(GunData data, Transform startPoint, Vector3 target)
    {
        _gunData = data;
        _startPoint = startPoint;
        transform.position = _startPoint.position;
        _target = target;

        gameObject.SetActive(true);
    }

    private void Update()
    {
        if (!_isStopGame)
        {
            if (_gunData.IsGrenade && Vector3.Distance(transform.position, _target) < 0.5)
            {
                Collider[] collisions = Physics.OverlapSphere(transform.position, _gunData.ExplosionRadius);
                foreach (Collider Object in collisions)
                    if (Object.TryGetComponent(out TakeDamage enemy))
                    {
                        enemy.TakedDamage(_gunData.Damage);
                    }
                PoolManager.Instance.ReturnObject(this.gameObject);
            }
            else if ((_gunData.IsLimitedLife && Vector3.Distance(_startPoint.position, transform.position) >= _gunData.TimeLife) || (transform.position.x > MainGameManager.MapBorders.x || transform.position.x < -MainGameManager.MapBorders.x || transform.position.z > MainGameManager.MapBorders.z || transform.position.z < -MainGameManager.MapBorders.z))
            {
                PoolManager.Instance.ReturnObject(this.gameObject);
            }
            else if (_gunData.IsGrenade)
            {
                transform.LookAt(_target);
                transform.Translate(_speed * Time.deltaTime * Vector3.forward);
            }
            else
            {
                transform.Translate(_speed * Time.deltaTime * Vector3.forward);
            }
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

    private void GameOverStopGame()
    {
        _isStopGame = true;
    }
}
