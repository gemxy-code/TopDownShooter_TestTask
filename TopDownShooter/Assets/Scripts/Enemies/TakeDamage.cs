using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    [SerializeField] private EnemyData _enemyData;

    private float _health;

    public void Spawned()
    {
        _health = _enemyData.Health;
    }

    public void TakedDamage(float damage)
    {
        _health -= damage;
        if(_health <= 0)
        {
            EventBus.SendEnemyDied(_enemyData.Score);
            PoolManager.Instance.ReturnObject(this.gameObject);
        }
    }
}
