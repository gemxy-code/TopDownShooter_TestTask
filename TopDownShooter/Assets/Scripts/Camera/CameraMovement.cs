using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private CharacterMovement _target;
    [SerializeField] private Camera _camera;

    private Vector3 _offset = new(0f, 2f, 0f);

    private void LateUpdate()
    {
        Vector3 newPosition = _target.transform.position + _offset;
        newPosition.x = Mathf.Clamp(newPosition.x, (WorldLimit.MapBorders.x - _camera.orthographicSize * _camera.aspect) * -1, WorldLimit.MapBorders.x - _camera.orthographicSize * _camera.aspect);
        newPosition.z = Mathf.Clamp(newPosition.z, (WorldLimit.MapBorders.z - _camera.orthographicSize) * -1, WorldLimit.MapBorders.z - _camera.orthographicSize);
        transform.position = newPosition;
    }
}
