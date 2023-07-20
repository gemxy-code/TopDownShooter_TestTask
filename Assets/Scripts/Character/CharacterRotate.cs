using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterRotate : MonoBehaviour
{
    [SerializeField] private float _speedRotate;

    private bool _isStopGame;
    private void Awake()
    {
        _isStopGame = false;
    }
    private void OnEnable()
    {
        EventBus.OnGameOver += GameOverStopGame;
    }
    private void OnDisable()
    {
        EventBus.OnGameOver -= GameOverStopGame;
    }

    void Update()
    {
        if (!_isStopGame && Mouse.current.leftButton.ReadValue() > 0)
        {
            Vector3 targetPosition = MainGameManager.MainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            Vector3 direction = (targetPosition - transform.position).normalized;
            direction.y = 0f;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(direction), _speedRotate * Time.deltaTime);
        }
    }

    private void GameOverStopGame()
    {
        _isStopGame = true;
    }
}
