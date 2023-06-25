using System.Collections;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _objects;
    [SerializeField] protected float _timerSpawn;

    protected GameObject[] _spawnedObjects;

    private void Awake()
    {
        Init();
        StartCoroutine(Spawn());
    }
    
    private void Init()
    {
        _spawnedObjects = new GameObject[_objects.Length];
        for (int i = 0; i < _objects.Length; i++)
        {
            GameObject newObject = Factory.CreateProduct(_objects[i]);
            newObject.transform.parent = transform;
            newObject.SetActive(false);
            _spawnedObjects[i] = newObject;
        }
    }

    protected int RandomSpawn() => Random.Range(0, _spawnedObjects.Length);

    protected IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(_timerSpawn);
            GameObject _spawnObject = _spawnedObjects[RandomSpawn()];

            _spawnObject.transform.position = CalculatePosition();
            _spawnObject.SetActive(true);
        }
    }

    protected abstract Vector3 CalculatePosition();

    public static void TakBack(GameObject Object) => Object.SetActive(false);
}
