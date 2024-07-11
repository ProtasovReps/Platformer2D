using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField, Min(1)] private float _spawnDelay;

    private GroundPlatformStash _groundPlatformStash;
    private ObjectPool<Enemy> _pool;

    public void Initialize(GroundPlatformStash groundPlatformStash)
    {
        _groundPlatformStash = groundPlatformStash;

        CreatePool();
        StartCoroutine(GetEnemiesDelayed());
    }

    public void ReleaseEnemy(Enemy enemy) => _pool.Release(enemy);

    private void CreatePool()
    {
        _pool = new ObjectPool<Enemy>(
            createFunc: () => Create(),
            actionOnGet: (enemy) => Get(enemy),
            actionOnRelease: (enemy) => enemy.Die(),
            actionOnDestroy: (enemy) => Destroy(enemy)
            );
    }

    private IEnumerator GetEnemiesDelayed()
    {
        var delay = new WaitForSeconds(_spawnDelay);
        bool isWorking = true;

        while (isWorking)
        {
            _pool.Get();
            yield return delay;
        }
    }

    private Enemy Create()
    {
        Enemy enemy = Instantiate(_enemy);
        enemy.Initialize(this);

        return enemy;
    }

    private void Get(Enemy enemy)
    {
        float upPosition = 1.5f;
        Vector2 randomPosition = _groundPlatformStash.GetRandomPlatform().GetRandomPosition(upPosition);
        
        enemy.transform.position = randomPosition;
        enemy.Revive();
    }
}