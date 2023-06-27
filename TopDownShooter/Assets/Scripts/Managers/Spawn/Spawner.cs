using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _objects;
    [SerializeField] protected float _timerSpawn;
    [SerializeField] private Camera _camera;

    private float _cameraMaxBorder = 0.9f;
    private float _cameraMinBorder = 0f;

    public List<GameObject> _spawnedObjects;

    protected abstract void StartOptions();

    private void Awake()
    {
        Init();
        StartCoroutine(Spawn());
        StartOptions();
    }
     
    private void Init()
    {
        _spawnedObjects = new List<GameObject>(_objects.Length);
        for (int i = 0; i < _objects.Length; i++)
        {
            GameObject newObject = Factory.CreateProduct(_objects[i]);
            newObject.transform.parent = transform;
            newObject.SetActive(false);
            _spawnedObjects.Add(newObject);
        }
    }

    protected int RandomSpawn() => Random.Range(0, _spawnedObjects.Count);

    protected IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(_timerSpawn);
            GameObject _spawnObject = _spawnedObjects[RandomSpawn()];
            _spawnObject.transform.position = CalculatePosition();
            _spawnObject.SetActive(true);
            _spawnObject.GetComponent<FadeAway>().Start();
        }
    }

    protected Vector3 CalculatePosition()
    {
        Vector3 positionmax = _camera.ViewportToWorldPoint(new Vector3(_cameraMaxBorder, _cameraMaxBorder, 0f));
        Vector3 positionmin = _camera.ViewportToWorldPoint(new Vector3(_cameraMinBorder, _cameraMinBorder, 0f));
        Vector3 newPosition = new Vector3(Random.Range(positionmin.x, positionmax.x), 0.5f, Random.Range(positionmin.z, positionmax.z));
        return newPosition;
    }

    public static void TakeBack(GameObject Object) => Object.SetActive(false);
}
