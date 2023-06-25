using UnityEngine;
using UnityEngine.Events;

public class UserInput : MonoBehaviour
{
    [SerializeField] private UnityEvent OnMouseClicked;

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
            OnMouseClicked.Invoke();
        }
    }
}
