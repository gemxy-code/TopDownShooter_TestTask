using UnityEngine;

public class MoveToCharacter : MonoBehaviour
{
    [SerializeField] private EnemyScriptableObjects _enemyData;

    private GameObject _target;

    private void Awake()
    {
        //Change method Find to one dependency Inject ? 
        _target = GameObject.Find("Character");
    }

    private void Update()
    {
        Vector3 direction = (_target.transform.position - transform.position).normalized;
        transform.Translate(direction * _enemyData.Speed * Time.deltaTime);
    }
}
