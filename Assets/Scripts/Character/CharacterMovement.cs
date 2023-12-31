using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float _defaultSpeed = 4f;
    [SerializeField] private UserInput _userInput;

    private float _speed;
    private float _halfSize;
    private void Awake()
    {
        _speed = _defaultSpeed;
        _halfSize = transform.localScale.x / 2;
    }

    private void OnEnable()
    {
        EventBus.OnSpeedBoosted += SpeedBoostHandler;
        EventBus.OnSpeedFalled += SpeedFallHandler;
    }

    private void OnDisable()
    {
        EventBus.OnSpeedBoosted -= SpeedBoostHandler;
        EventBus.OnSpeedFalled -= SpeedFallHandler;
    }

    private void Update()
    {
        Vector3 moveDirection = new Vector3(_userInput.MoveDirection.x, 0, _userInput.MoveDirection.y);
        Vector3 newPosition = transform.position + (Time.deltaTime * (moveDirection * _speed));
        newPosition.x = Mathf.Clamp(newPosition.x, (MainGameManager.MapBorders.x - _halfSize) * -1, MainGameManager.MapBorders.x - _halfSize);
        newPosition.z = Mathf.Clamp(newPosition.z, (MainGameManager.MapBorders.z - _halfSize) * -1, MainGameManager.MapBorders.z - _halfSize);
        transform.position = newPosition;
    }

    private void SpeedBoostHandler(float value)
    {
        _speed *= value;
    }

    private void SpeedFallHandler(float value)
    {
        _speed /= value;
    }
}
