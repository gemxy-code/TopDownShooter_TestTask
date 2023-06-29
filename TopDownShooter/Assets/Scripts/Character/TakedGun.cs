using UnityEngine;

public class TakedGun : MonoBehaviour
{
    [SerializeField] private Transform _gunPosition;

    private Gun _currentGun;
    private bool _isStopGame;
    private void Awake()
    {
        _isStopGame = false;
    }
    private void OnEnable()
    {
        EventBus.OnGameOver += GameOverStopGame;
    }
    private void OnDisable()
    {
        EventBus.OnGameOver -= GameOverStopGame;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Gun takedGun))
        {
            EventBus.SendGunTaked(other.gameObject);
            TakeGun(takedGun);
            other.gameObject.transform.SetParent(_gunPosition);
            other.transform.SetPositionAndRotation(_gunPosition.position, _gunPosition.rotation);
            
            takedGun.IsCanShoot = true;        
        }
    }

    private void Update()
    {
        if (!_isStopGame && Input.GetMouseButton(0))
        {
            Vector3 targetPosition = MainGameManager.MainCamera.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.y = 0.5f;
            if (_currentGun != null)
            {
                _currentGun.Shoot(targetPosition);
            }
        }
    }

    private void TakeGun(Gun takedGun)
    {
        _currentGun = takedGun;
    }

    private void GameOverStopGame()
    {
        _isStopGame = true;
    }
}
