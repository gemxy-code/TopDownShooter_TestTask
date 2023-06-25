using System.Collections;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private CharacterMovement _target;
    [SerializeField] private Camera _camera;

    private Vector3 _offset = new(0f, 2f, 0f);

    private float _horizonalBorder;
    private float _verticalBorder;

    private void Awake()
    {
        StartCoroutine(Movement());
        _horizonalBorder = _camera.orthographicSize * _camera.aspect;
        _verticalBorder = _camera.orthographicSize;
    }

    private IEnumerator Movement()
    {
        while (true)
        {
            Vector3 newPosition = _target.transform.position + _offset;
            newPosition.x = Mathf.Clamp(newPosition.x, (WorldLimit.MapBorders.x - _horizonalBorder) * -1, WorldLimit.MapBorders.x - _horizonalBorder);
            newPosition.z = Mathf.Clamp(newPosition.z, (WorldLimit.MapBorders.z - _verticalBorder) * -1, WorldLimit.MapBorders.z - _verticalBorder);
            transform.position = newPosition;
            yield return null;
        }
    }
}
