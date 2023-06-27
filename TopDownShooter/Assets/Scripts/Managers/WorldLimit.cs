using UnityEngine;

public class MapBorders
{
    public int x = 20;
    public int z = 15;
}

public class WorldLimit : MonoBehaviour
{
    private static MapBorders _mapBorders = new MapBorders();
    public static MapBorders MapBorders { get => _mapBorders; }
}
