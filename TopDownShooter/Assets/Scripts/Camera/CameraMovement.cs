using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private CharacterMovement _target;
    [SerializeField] Vector3 _offset;

    private void LateUpdate()
    {
        Vector3 newPosition = _target.transform.position + _offset;
        float xPosition = MainGameManager.MapBorders.x - MainGameManager.OrthographicSize.x;
        float zPosition = MainGameManager.MapBorders.z - MainGameManager.OrthographicSize.y;
        newPosition.x = Mathf.Clamp(newPosition.x, xPosition * -1, xPosition);
        newPosition.z = Mathf.Clamp(newPosition.z, zPosition * -1, zPosition);
        transform.position = newPosition;
    }
}
