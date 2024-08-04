using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class CollectibleSpawner : MonoBehaviour
{
    [SerializeField] private float _spawnDelay = 10f;

    private GroundPlatformStash _groundPlatformStash;
    private Warehouse _collectibleStash;
    private List<Collectible> _spawnedCollectibles;
    private ObjectPool<Collectible> _pool;

    private void OnEnable()
    {
        if(_spawnedCollectibles != null && _spawnedCollectibles.Count > 0)
        {
            foreach(var collectible in _spawnedCollectibles)
            {
                collectible.PickedUp += ReleaseCollectible;
            }
        }
    }

    private void OnDisable()
    {
        if (_spawnedCollectibles != null && _spawnedCollectibles.Count > 0)
        {
            foreach (var collectible in _spawnedCollectibles)
            {
                collectible.PickedUp -= ReleaseCollectible;
            }
        }
    }

    public void Initialize(GroundPlatformStash groundPlatformStash, Warehouse collectibleStash)
    {
        _collectibleStash = collectibleStash;
        _groundPlatformStash = groundPlatformStash;
        _spawnedCollectibles = new List<Collectible>();
        
        CreatePool();
        StartCoroutine(GetCollectiblesDelayed());
    }

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
        collectible.PickedUp += ReleaseCollectible;
       
        _spawnedCollectibles.Add(collectible);
        return collectible;
    }

    private void Get(Collectible collectible)
    {
        float upPosition = 1.5f;
        Vector2 randomPosition = _groundPlatformStash.GetRandomPlatform().GetRandomPosition(upPosition);

        collectible.transform.position = randomPosition;
        collectible.gameObject.SetActive(true);
    }

    private void ReleaseCollectible(Collectible collectible) => _pool.Release(collectible);
}
