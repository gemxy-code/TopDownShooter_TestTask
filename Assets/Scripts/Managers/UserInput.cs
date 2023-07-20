using UnityEngine;
using Zenject;

public class UserInput : MonoBehaviour
{
    private PlayerInput _input;
    private Vector2 _moveDirection;
    public Vector2 MoveDirection { get => _moveDirection; }

    [Inject]
    public void Construct (PlayerInput input)
    {
        _input = input;
        _input.Player.Enable();
    }    

    private void LateUpdate()
    {
        _moveDirection = _input.Player.Move.ReadValue<Vector2>();
    }

    private void OnEnable() => EventBus.OnGameOver += GameOverStopGame;
    private void OnDisable() => EventBus.OnGameOver -= GameOverStopGame;

    private void GameOverStopGame()
    {
        _input.Player.Disable();
    }
}
