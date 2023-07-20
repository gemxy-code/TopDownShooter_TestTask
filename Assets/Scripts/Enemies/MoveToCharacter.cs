using UnityEngine;

public class MoveToCharacter : MonoBehaviour
{
    [SerializeField] private EnemyData _enemyData;

    private GameObject _target;
    private bool _isStopGame;

    private void OnEnable()
    {
        EventBus.OnGameOver += GameOverStopGame;
    }
    private void OnDisable()
    {
        EventBus.OnGameOver -= GameOverStopGame;
    }

    private void Awake()
    {
        _isStopGame = false;
        _target = MainGameManager.Character;
    }

    private void Update()
    {
        if (!_isStopGame)
        {
            Vector3 direction = (_target.transform.position - transform.position).normalized;
            transform.Translate(_enemyData.Speed * Time.deltaTime * direction);
        }
    }

    private void GameOverStopGame()
    {
        _isStopGame = true;
    }
}
