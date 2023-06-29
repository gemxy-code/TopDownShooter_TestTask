using UnityEngine;

public class UserInput : MonoBehaviour
{
    private bool _isStopGame;

    private float _moveVertical;
    public float MoveVertical { get => _moveVertical; }

    private float _moveHorizontal;
    public float MoveHorizontal { get => _moveHorizontal; }

    private void OnEnable() => EventBus.OnGameOver += GameOverStopGame;
    private void OnDisable() => EventBus.OnGameOver -= GameOverStopGame;
    private void Awake()
    {
        _isStopGame = false;
    }
    private void LateUpdate()
    {
        if(!_isStopGame)
        {
            _moveVertical = Input.GetAxis("Vertical");
            _moveHorizontal = Input.GetAxis("Horizontal");
        }       
    }
    private void GameOverStopGame()
    {
        _isStopGame = true;
        _moveVertical = 0;
        _moveHorizontal = 0;
    }
}
