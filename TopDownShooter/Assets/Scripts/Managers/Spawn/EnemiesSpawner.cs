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
        //Change this method with    Camera.main.ViewportToWorldPoint(1.1f, 1f, 1.1f); max and 0 min potitions on screen with distance > 1 and WorldLimit

        return new Vector3(_camera.transform.position.x, 0.5f, _camera.transform.position.z)  + new Vector3(Random.Range(WorldLimit.MapBorders.x * -1, WorldLimit.MapBorders.x), 0.5f, Random.Range(WorldLimit.MapBorders.z * -1, WorldLimit.MapBorders.z));
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
