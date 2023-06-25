using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _pooledObjects;
    [SerializeField] private int _pooledObjectsCount;

    private Dictionary<string, Queue<GameObject>> _pool;
    private Dictionary<string, GameObject> _poolsContainers;

    public static PoolManager Instance;

    private void Awake()
    {
        Init();
        if(Instance == null)
        {
            Instance = this;
        }
    }

    private void Init()
    {
        _pool = new Dictionary<string, Queue<GameObject>>();
        _poolsContainers = new Dictionary<string, GameObject>();

        foreach(GameObject Object in _pooledObjects)
        {
            GameObject emptyObject = new GameObject(Object.name + " Pool");
            emptyObject.transform.parent = transform;

            _poolsContainers.Add(Object.name, emptyObject);   
            _pool.Add(Object.name, new Queue<GameObject>());

            for(int i = 0; i < _pooledObjectsCount; i++)
            {
                CreateNewObject(Object);
            }
        }
    }

    private GameObject CreateNewObject(GameObject Object)
    {
        GameObject newObject = Factory.CreateProduct(Object);
        newObject.transform.parent = _poolsContainers[Object.name].transform;
        newObject.SetActive(false);
        _pool[newObject.name].Enqueue(newObject);
        return newObject;
    }

    public GameObject RentObject(GameObject Object)
    {
        GameObject rentedObject;
        if (_pool[Object.name].Count > 0)
        {
            rentedObject = _pool[Object.name].Dequeue();
        }
        else
        {
            rentedObject = CreateNewObject(Object);
        }            
        rentedObject.SetActive(true);
        return rentedObject;
    }

    public void ReturnObject(GameObject Object)
    {
        Object.SetActive(false);
        _pool[Object.name].Enqueue(Object);
    }

}
