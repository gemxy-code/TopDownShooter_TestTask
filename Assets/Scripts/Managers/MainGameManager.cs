using UnityEngine;

public class MapBorders
{
    public int x = 20;
    public int z = 15;
}

public class MainGameManager : MonoBehaviour
{
    private static Camera _camera;
    private static MapBorders _mapBorders = new MapBorders();
    private static GameObject _character;  
    private static Vector2 _orthographicSize;
    private static Vector3 _maxScreenPoints;
    private static Vector3 _minScreenPoints;
    private static string _mainMenuScene = "MainMenu";

    public static Camera MainCamera { get => _camera; }
    public static MapBorders MapBorders { get => _mapBorders; }
    public static GameObject Character { get => _character; }
    public static Vector2 OrthographicSize { get => _orthographicSize; }
    public static Vector2 MaxScreenPoints { get => _maxScreenPoints; }
    public static Vector2 MinScreenPoints { get => _minScreenPoints; }
    public static string MainMenuScene { get => _mainMenuScene; }

    private void Awake()
    {
        _character = GameObject.Find("Character");
        _camera = Camera.main;
    }

    private void Update()
    {
        _orthographicSize = new Vector2(_camera.orthographicSize * _camera.aspect, _camera.orthographicSize);
        _maxScreenPoints = _camera.ViewportToWorldPoint(new Vector3(1f, 1f, 0f));
        _minScreenPoints = _camera.ViewportToWorldPoint(new Vector3(0f, 0f, 0f));
    }
}
