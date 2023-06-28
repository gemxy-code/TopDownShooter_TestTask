using UnityEngine;

public class ShowUI : MonoBehaviour
{
    private int _planeVisibleValue = 1;

    private void OnEnable()
    {
        EventBus.OnGameOver += Show;
    }
    private void OnDisable()
    {
        EventBus.OnGameOver -= Show;
    }


    private void Show()
    {
        if (gameObject.TryGetComponent(out Canvas canvas))
        {
            canvas.planeDistance = _planeVisibleValue;
        }
    }
}
