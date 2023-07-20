using UnityEngine;

public class HideUI : MonoBehaviour
{
    private int _planeHideValue = 0;

    private void OnEnable()
    {
        EventBus.OnGameOver += Hide;
    }
    private void OnDisable()
    {
        EventBus.OnGameOver -= Hide;
    }

    private void Hide()
    {
        if(gameObject.TryGetComponent(out Canvas canvas))
        {
            canvas.planeDistance = _planeHideValue;
        }
    }
}
