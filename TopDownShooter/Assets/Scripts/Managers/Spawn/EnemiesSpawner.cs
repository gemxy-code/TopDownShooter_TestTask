using System.Collections;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField] private EnemyData[] _enemiesDatas;
    [SerializeField] private float _spawnTimer; 

    private readonly float _minusTime = 0.1f;
    private readonly float _timeForBoostTime = 10f;
    private float _timer;

    private float _allChances = 0;
    private readonly System.Random _rand = new System.Random();

    private void OnEnable()
    {
        EventBus.OnGameOver += GameOverStopSpawn;
    }
    private void OnDisable()
    {
        EventBus.OnGameOver -= GameOverStopSpawn;
    }

    private void Awake()
    {
        _timer = 0f;
        CalculateWeight();
        StartCoroutine(SpawnedEnemy());
    }

    private void Update()
    {
        if (_spawnTimer > 0.5f)
        {
            _timer += Time.deltaTime;
            if (_timer >= _timeForBoostTime)
            {
                _spawnTimer -= _minusTime;
                _timer = 0f;
            }
        }
    }

    private IEnumerator SpawnedEnemy()
    {
        while(true)
        {
            yield return new WaitForSeconds(_spawnTimer);
            ChooseRandomEnemy();
        }
    }

    private void ChooseRandomEnemy()
    {
        int index = TakeIndexRandomEnemy();
        GameObject enemy = PoolManager.Instance.RentObject(_enemiesDatas[index].Prefab);
        enemy.transform.position = CalculatePosition();
        enemy.GetComponent<TakeDamage>().Spawned();
        enemy.SetActive(true);
        Debug.Log(_timer);
    }

    private int TakeIndexRandomEnemy()
    {
        double random = _rand.NextDouble() * _allChances;
        for (int i = 0; i < _enemiesDatas.Length; i++)
        {
            if (_enemiesDatas[i].Weight >= random)
            {
                return i;
            }
        }
        return 0;
    }

    private Vector3 CalculatePosition()
    {
        Vector3 newPosition = Vector3.zero;
        bool _isCanSpawn = false;
        while(!_isCanSpawn)
        {
            int randomSide = Random.Range(0, 4);
            switch (randomSide)
            {
                //BottomSide Position
                case 0:
                    if(((MainGameManager.MapBorders.z * -1) - MainGameManager.MinScreenPoints.y) < 0)
                    {
                        newPosition = new Vector3(Random.Range(-MainGameManager.MapBorders.x, MainGameManager.MapBorders.x), 0.5f, MainGameManager.MinScreenPoints.y);
                        _isCanSpawn = true;
                    }                   
                    break;
                //LeftSide Position
                case 1:
                    if (((MainGameManager.MapBorders.x * -1) - MainGameManager.MinScreenPoints.x) < 0)
                    {
                        newPosition = new Vector3(MainGameManager.MinScreenPoints.x, 0.5f, Random.Range(-MainGameManager.MapBorders.z, MainGameManager.MapBorders.z));
                        _isCanSpawn = true;
                    }
                    break;
                //TopSide Position
                case 2:
                    if ((MainGameManager.MapBorders.z - MainGameManager.MaxScreenPoints.y) > 0)
                    {

                        newPosition = new Vector3(Random.Range(-MainGameManager.MapBorders.x, MainGameManager.MapBorders.x), 0.5f, MainGameManager.MaxScreenPoints.y);
                        _isCanSpawn = true;
                    }
                    break;
                //RightSide Position
                case 3:
                default:
                    if ((MainGameManager.MapBorders.x - MainGameManager.MaxScreenPoints.x) > 0)
                    {

                        newPosition = new Vector3(MainGameManager.MaxScreenPoints.x, 0.5f, Random.Range(-MainGameManager.MapBorders.z, MainGameManager.MapBorders.z));
                        _isCanSpawn = true;
                    }
                    break;
            }
        }            
        return newPosition;
    }
    
    private void CalculateWeight()
    {
        for (int i = 0; i < _enemiesDatas.Length; i++)
        {
            _allChances += _enemiesDatas[i].SpawnChance;
            _enemiesDatas[i].Weight = _allChances;
        }
    }

    private void GameOverStopSpawn()
    {
        StopAllCoroutines();
    }
}
