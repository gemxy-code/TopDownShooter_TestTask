using UnityEngine;

public class GunsSpawner : Spawner
{
    private GameObject _currentGun;

    private void OnEnable()
    {
        EventBus.OnGunTaked += SetGun;
    }
    private void OnDisable()
    {
        EventBus.OnGunTaked -= SetGun;
    }

    protected override void StartOptions()
    {
        _currentGun = null;
    }

    private void SetGun(GameObject gun)
    {
        if(_currentGun != null)
        {
            _spawnedObjects.Add(_currentGun);
            _currentGun.transform.parent = this.transform;
            _currentGun.SetActive(false);
        }
        _spawnedObjects.Remove(gun);
        _currentGun = gun;
    }
}
