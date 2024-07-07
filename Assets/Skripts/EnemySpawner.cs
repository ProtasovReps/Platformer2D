using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyCharacter _enemy;
    [SerializeField] private float _spawnDelay;

    private GroundPlatformStash _groundPlatformStash;
    private ObjectPool<EnemyCharacter> _pool;

    public void Initialize(GroundPlatformStash groundPlatformStash)
    {
        _groundPlatformStash = groundPlatformStash;
        CreatePool();
        StartCoroutine(GetEnemiesDelayed());
    }

    public void ReleaseEnemy(EnemyCharacter enemy) => _pool.Release(enemy);

    private void CreatePool()
    {
        _pool = new ObjectPool<EnemyCharacter>(
            createFunc: () => Create(),
            actionOnGet: (enemy) => Get(enemy),
            actionOnRelease: (enemy) => enemy.gameObject.SetActive(false),
            actionOnDestroy: (enemy) => Destroy(enemy)
            );
    }

    private EnemyCharacter Create()
    {
        EnemyCharacter enemy = Instantiate(_enemy);
        enemy.Initialize(this);

        return enemy;
    }

    private void Get(EnemyCharacter enemy)
    {
        float upPosition = 1.5f;
        Vector2 randomPosition = _groundPlatformStash.GetRandomPlatform().GetRandomPosition(upPosition);
        
        enemy.transform.position = randomPosition;
        enemy.gameObject.SetActive(true);
        enemy.Revive();
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
}
