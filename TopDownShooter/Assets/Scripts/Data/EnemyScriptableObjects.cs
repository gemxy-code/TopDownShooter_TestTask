using UnityEngine;

[CreateAssetMenu (fileName = "new Enemy data", menuName = "Scriptable Objects/Enemy Data", order = 51)]
public class EnemyScriptableObjects : ScriptableObject
{
    [SerializeField] private GameObject _prefab;
    public GameObject Prefab { get => _prefab; } 


    [SerializeField] private int _health;
    public int Health { get => _health; }


    [SerializeField] private int _speed;
    public int Speed { get => _speed; }


    [SerializeField] private int _score;
    public int Score { get => _score; }


    [SerializeField] [Range(0, 100)] private int _spawnChance;
    public int SpawnChance { get => _spawnChance; }

    [HideInInspector] public float Weight;
}
