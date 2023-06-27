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
            OnMouseClicked?.Invoke(_camera.ScreenToWorldPoint(Input.mousePosition));
        }
    }
}
