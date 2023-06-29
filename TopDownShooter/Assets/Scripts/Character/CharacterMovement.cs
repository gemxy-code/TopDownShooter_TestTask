using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float _defaultSpeed = 4f;
    [SerializeField] private UserInput _input;

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
        if(_input.MoveHorizontal != 0 || _input.MoveVertical != 0)
        {
            Vector3 newPosition = transform.position + ((Vector3.right * _input.MoveHorizontal) + (Vector3.forward * _input.MoveVertical)) * _speed * Time.deltaTime;
            newPosition.x = Mathf.Clamp(newPosition.x, (MainGameManager.MapBorders.x - _halfSize) * -1, MainGameManager.MapBorders.x - _halfSize);
            newPosition.z = Mathf.Clamp(newPosition.z, (MainGameManager.MapBorders.z - _halfSize) * -1, MainGameManager.MapBorders.z - _halfSize);
            transform.position = newPosition;
        }       
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
