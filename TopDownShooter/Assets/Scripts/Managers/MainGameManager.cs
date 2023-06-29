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

    public static Camera MainCamera { get => _camera; }
    public static MapBorders MapBorders { get => _mapBorders; }
    public static GameObject Character { get => _character; }
    public static Vector2 OrthographicSize { get => _orthographicSize; }

    private void Awake()
    {
        _character = GameObject.Find("Character");
        _camera = Camera.main;
    }

    private void Update()
    {
        _orthographicSize = new Vector2(_camera.orthographicSize * _camera.aspect, _camera.orthographicSize);
    }
}
