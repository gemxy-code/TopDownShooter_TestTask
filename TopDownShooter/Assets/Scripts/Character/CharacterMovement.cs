using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float _defaultSpeed = 4f;
    [SerializeField] private float _rotate;
    [SerializeField] private UserInput _input;

    private float _speed;

    private void Awake()
    {
        _speed = _defaultSpeed;
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
            newPosition.x = Mathf.Clamp(newPosition.x, (WorldLimit.MapBorders.x - transform.localScale.x / 2) * -1, WorldLimit.MapBorders.x - transform.localScale.x / 2);
            newPosition.z = Mathf.Clamp(newPosition.z, (WorldLimit.MapBorders.z - transform.localScale.z / 2) * -1, WorldLimit.MapBorders.z - transform.localScale.z / 2);
            transform.position = newPosition;
        }       
    }

    private void SpeedBoostHandler(float value)
    {
        _speed *= value;
    }

    private void SpeedFallHandler()
    {
        _speed = _defaultSpeed;
    }

}
