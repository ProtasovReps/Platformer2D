using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class CollectibleSpawner : MonoBehaviour
{
    [SerializeField] private float _spawnDelay = 10f;

    private GroundPlatformStash _groundPlatformStash;
    private CollectibleStash _collectibleStash;
    private ObjectPool<Collectible> _pool;

    public void Initialize(GroundPlatformStash groundPlatformStash, CollectibleStash collectibleStash)
    {
        _collectibleStash = collectibleStash;
        _groundPlatformStash = groundPlatformStash;
        
        CreatePool();
        StartCoroutine(GetCollectiblesDelayed());
    }

    public void ReleaseCollectible(Collectible collectible) => _pool.Release(collectible);

    private void CreatePool()
    {
        _pool = new ObjectPool<Collectible>(
            createFunc: () => Create(),
            actionOnGet: (collectible) => Get(collectible),
            actionOnRelease: (collectible) => collectible.gameObject.SetActive(false),
            actionOnDestroy: (collectible) => Destroy(collectible)
            );
    }

    private IEnumerator GetCollectiblesDelayed()
    {
        var delay = new WaitForSeconds(_spawnDelay);
        bool isWorking = true;

        while (isWorking)
        {
            _pool.Get();
            yield return delay;
        }
    }

    private Collectible Create()
    {
        Collectible collectible = Instantiate(_collectibleStash.GetRandomCollectible());
        collectible.Initialize(this);
        return collectible;
    }

    private void Get(Collectible collectible)
    {
        float upPosition = 1.5f;
        Vector2 randomPosition = _groundPlatformStash.GetRandomPlatform().GetRandomPosition(upPosition);

        collectible.transform.position = randomPosition;
        collectible.gameObject.SetActive(true);
    }
}
