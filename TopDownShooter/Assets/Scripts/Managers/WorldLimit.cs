using UnityEngine;

public class MapBorders
{
    public int x = 20;
    public int z = 15;
}

public class WorldLimit : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private static Vector2 _screenBounds;
    private static MapBorders _mapBorders = new MapBorders();

    public static Vector2 ScreenBounds { get => _screenBounds; }
    public static MapBorders MapBorders { get => _mapBorders; }

    private void Awake()
    {
        _screenBounds = _camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, _camera.transform.position.z));
    }
}
