using UnityEngine;

//For GameOver and Game UI ???
public class HideVisibleMenu : MonoBehaviour
{
    private int _planeVisibleValue = 1;
    private int _planeHideValue = 0;

    private void Hide()
    {
        if(gameObject.TryGetComponent(out Canvas canvas))
        {
            canvas.planeDistance = _planeHideValue;
        }
    }

    private void Show()
    {

    }
}
