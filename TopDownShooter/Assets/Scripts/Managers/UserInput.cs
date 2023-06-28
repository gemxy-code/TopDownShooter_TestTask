using System;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    public static event Action <Vector3> OnMouseClicked;
    [SerializeField] private Camera _camera;

    private float _moveVertical;
    public float MoveVertical { get => _moveVertical; }

    private float _moveHorizontal;
    public float MoveHorizontal { get => _moveHorizontal;}        

    private void LateUpdate()
    {
        _moveVertical = Input.GetAxis("Vertical");
        _moveHorizontal = Input.GetAxis("Horizontal");

        if(Input.GetMouseButton(0))
        {
            Vector3 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.y = 0f;
            OnMouseClicked?.Invoke(mousePosition);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Vector3 _maxPoints = _camera.ViewportToWorldPoint(new Vector3(1f, 0f, 1f));
            Debug.Log(new Vector3(WorldLimit.MapBorders.x - _maxPoints.x, _maxPoints.y, WorldLimit.MapBorders.z - _maxPoints.z));
        }
    }
}
