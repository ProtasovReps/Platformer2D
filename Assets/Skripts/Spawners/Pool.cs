using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class Pool : MonoBehaviour
{
    [SerializeField] private float _spawnDelay = 10f;
    [SerializeField] private Stash<PoolingObject> _poolingObjectStash;
    [SerializeField] private Stash<Ground> _groundPlatformStash;
    
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
        PoolingObject poolingObject = Instantiate(_poolingObjectStash.GetRandomItem());
        
        poolingObject.WorkedOut += Release;
        return poolingObject;
    }

    private void Get(PoolingObject pollingObject)
    {
        Ground randomGroundPlatform = _groundPlatformStash.GetRandomItem();
        Vector2 randomGroundPosition = randomGroundPlatform.GetRandomPosition();

        pollingObject.ChangePosition(randomGroundPosition);
        pollingObject.Appear();
    }

    private void Release(PoolingObject pollingObject) => _pool.Release(pollingObject);

    private void Destroy(PoolingObject poolingObject)
    {
        poolingObject.WorkedOut -= Release;
        Destroy(poolingObject);
    }
}
