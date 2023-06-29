using UnityEngine;

public class ZonesGenerator : MonoBehaviour
{
    [SerializeField] private Zone[] _zones;
    [SerializeField] private float _distanceBetweenZones;
    [SerializeField] private int _zonesLayer;

    private Vector3 _borders;

    private void Start()
    {
        StartGenerate();
    }

    private void StartGenerate()
    {
        foreach (Zone zone in _zones)
        {
            _borders = new Vector3(MainGameManager.MapBorders.x - zone.Radius - _distanceBetweenZones, 0.5f, MainGameManager.MapBorders.z - zone.Radius - _distanceBetweenZones);
            int count = 0;
            while(zone.CountOnMap > count)
            {
                Vector3 _point = GeneratePoint();
                if (Physics.OverlapSphere(_point,  zone.Radius + _distanceBetweenZones, zone.ZonesMask.value).Length == 0)
                {
                    Instantiate(zone.gameObject, _point, Quaternion.identity);
                    count ++;
                }
            }
        }
    }
    private Vector3 GeneratePoint()
    {
        return new Vector3(Random.Range(_borders.x * -1, _borders.x), _borders.y, Random.Range(_borders.z * -1, _borders.z));
    }
}
