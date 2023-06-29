public class BonusesSpawner : Spawner
{
    private void OnEnable()
    {
        EventBus.OnGameOver += GameOverStopSpawn;
    }
    private void OnDisable()
    {
        EventBus.OnGameOver -= GameOverStopSpawn;
    }

    private void GameOverStopSpawn()
    {
        CancelInvoke();
    }
}
