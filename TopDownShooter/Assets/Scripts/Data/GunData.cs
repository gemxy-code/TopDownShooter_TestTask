using UnityEngine;

[CreateAssetMenu (fileName ="New Gun data", menuName ="Scriptable Objects/Gun data", order = 51)]
public class GunData : ScriptableObject
{

    [SerializeField] private float _shootSpeed;
    public float ShootSpeed { get => _shootSpeed; }

    [SerializeField] private float _damage;
    public float Damage { get => _damage; }

    [SerializeField] private bool _isGrenade;
    public bool IsGrenade { get => _isGrenade; }


    [SerializeField] private float _explosionRadius;
    public float ExplosionRadius { get => _explosionRadius; }


    [SerializeField] private bool _isLimitedLife;
    public bool IsLimitedLife { get => _isLimitedLife; }


    [SerializeField] private float _timeLife;
    public float TimeLife { get => _timeLife; }

}
