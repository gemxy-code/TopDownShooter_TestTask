using System.Collections;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField] private EnemyScriptableObjects[] _enemiesDatas;
    [SerializeField] private Camera _camera;
    [SerializeField] private float _spawnTimer;

    private float _minusTime = 0.1f;
    private float _timeForBoostTime = 10f;

    private float _height; //        
    private float _width;//


    private float _allChances = 0;
    private System.Random _rand = new System.Random();

    private void Awake()
    {
        _timeForBoostTime = Time.time;
        CalculateWeight();
        StartCoroutine(SpawnedEnemy());
    }

    private void Update()
    {
        if(Time.time - _timeForBoostTime >= 10f)
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
            }
        }
    }

    private Vector3 CalculatePosition()
    {
        _height = _camera.orthographicSize + 1;//
        _width = _camera.orthographicSize * _camera.aspect + 1;//
        Vector3 position = new Vector3(_camera.transform.position.x, 0.5f, _camera.transform.position.z)  + new Vector3(Random.Range(WorldLimit.MapBorders.x * -1, WorldLimit.MapBorders.x), 0.5f, Random.Range(WorldLimit.MapBorders.z * -1, WorldLimit.MapBorders.z));
        return position;
    }

    private void CalculateWeight()
    {
        for (int i = 0; i < _enemiesDatas.Length; i++)
        {
            _allChances += _enemiesDatas[i].SpawnChance;
            _enemiesDatas[i].Weight = _allChances;
        }
    }
}
