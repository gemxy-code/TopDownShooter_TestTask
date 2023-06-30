using UnityEngine;

public class GunsSpawner : Spawner
{
    private GameObject _currentGun = null;

    private void OnEnable()
    {
        EventBus.OnGunTaked += SetGun;
        EventBus.OnGameOver += GameOverStopSpawn;
    }
    private void OnDisable()
    {
        EventBus.OnGunTaked -= SetGun;
        EventBus.OnGameOver -= GameOverStopSpawn;
    }

    private void SetGun(GameObject gun)
    {
        if(_currentGun != null)
        {
            _spawnedObjects.Add(_currentGun);
            _currentGun.GetComponent<BoxCollider>().enabled = true;
            _currentGun.transform.parent = this.transform;
            _currentGun.SetActive(false);
        }
        _spawnedObjects.Remove(gun);
        _currentGun = gun;
    }

    private void GameOverStopSpawn()
    {
        CancelInvoke();
    }
}
