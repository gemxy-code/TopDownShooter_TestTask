using UnityEngine;

public abstract class Zone : MonoBehaviour
{
    [SerializeField] private LayerMask _zonesMask;
    public LayerMask ZonesMask { get => _zonesMask; }

    [SerializeField] private float _radius;
    public float Radius { get => _radius; }

    [SerializeField] private int _countOnMap;
    public int CountOnMap { get => _countOnMap; }

    protected abstract void Activate();

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CharacterMovement character))
            Activate();
    }
}
