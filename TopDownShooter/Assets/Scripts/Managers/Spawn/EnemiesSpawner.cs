using System.Collections;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField] private EnemyData[] _enemiesDatas;
    [SerializeField] private Camera _camera;
    [SerializeField] private float _spawnTimer; 

    private float _minusTime = 0.1f;
    private float _timeForBoostTime = 10f;

    private float _allChances = 0;
    private System.Random _rand = new System.Random();

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
        _timeForBoostTime = Time.time;
        CalculateWeight();
        StartCoroutine(nameof(SpawnedEnemy));
    }

    private void Update()
    {
        if(Time.time - _timeForBoostTime >= 10f && _spawnTimer > 0.5f)
        {
            _spawnTimer -= _minusTime;
            _timeForBoostTime = Time.time;
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
        double random = _rand.NextDouble();
        for(int i = 0; i < _enemiesDatas.Length; i++)
        {
            if (random >= _enemiesDatas[i].Weight/_allChances)
            {
                GameObject enemy = PoolManager.Instance.RentObject(_enemiesDatas[i].Prefab);
                enemy.transform.position = CalculatePosition();
                enemy.GetComponent<TakeDamage>().Spawned();
                enemy.SetActive(true);
            }
        }
    }

    private Vector3 CalculatePosition()
    {

        //Move to MainGameManager
        Vector3 _maxScreenPoints =  _camera.ViewportToWorldPoint(new Vector3(1f, 1f, 0f));
        Vector3 _minScreenPoints = _camera.ViewportToWorldPoint(new Vector3(0f, 0f, 0f));
        Vector3 newPosition;
        int randomSide = Random.Range(0, 4);

        switch (randomSide)
        {
            case 0:
                //BottomSide Position
                newPosition = new Vector3(Random.Range(-MainGameManager.MapBorders.x, MainGameManager.MapBorders.x), 0.5f, _minScreenPoints.z);
                break;
            case 1:
                //LeftSide Position
                newPosition = new Vector3(_minScreenPoints.x, 0.5f, Random.Range(-MainGameManager.MapBorders.z, MainGameManager.MapBorders.z));
                break;
            case 2:
                //TopSide Position
                newPosition = new Vector3(Random.Range(-MainGameManager.MapBorders.x, MainGameManager.MapBorders.x), 0.5f, _maxScreenPoints.z);
                break;
            case 3:
                //RightSide Position
                newPosition = new Vector3(_maxScreenPoints.x, 0.5f, Random.Range(-MainGameManager.MapBorders.z, MainGameManager.MapBorders.z));
                break;
            default:
                newPosition = new Vector3(_minScreenPoints.z, 0.5f, Random.Range(-MainGameManager.MapBorders.z, MainGameManager.MapBorders.z));
                break;
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
