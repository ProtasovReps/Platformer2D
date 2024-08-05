using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class Pool : MonoBehaviour
{
    [SerializeField] private float _spawnDelay = 10f;
    [SerializeField] private PoolingObjectStash _stash;
    [SerializeField] private GroundPlatformStash _groundPlatformStash;
    
    private ObjectPool<PoolingObject> _pool;

    public void Initialize()
    {
        CreatePool();
        StartCoroutine(GetDelayed());
    }

    private void CreatePool()
    {
        _pool = new ObjectPool<PoolingObject>(
        createFunc: () => Create(),
        actionOnGet: (poolingObject) => Get(poolingObject),
        actionOnRelease: (poolingObject) => poolingObject.Release(),
        actionOnDestroy: (poolingObject) => Destroy(poolingObject)
        );
    }

    private IEnumerator GetDelayed()
    {
        var delay = new WaitForSeconds(_spawnDelay);
        bool isWorking = true;

        while (isWorking)
        {
            _pool.Get();
            yield return delay;
        }
    }

    private PoolingObject Create()
    {
        PoolingObject poolingObject = Instantiate(_stash.GetRandomPoolingObject());
        
        poolingObject.ReadyToRelease += Release;
        return poolingObject;
    }

    private void Get(PoolingObject pollingObject)
    {
        float upPosition = 1.5f;
        Vector2 randomPosition = _groundPlatformStash.GetRandomPlatform().GetRandomPosition(upPosition);

        pollingObject.ChangePosition(randomPosition);
        pollingObject.Appear();
    }

    private void Release(PoolingObject pollingObject) => _pool.Release(pollingObject);

    private void Destroy(PoolingObject poolingObject)
    {
        poolingObject.ReadyToRelease -= Release;
        Destroy(poolingObject);
    }
}
