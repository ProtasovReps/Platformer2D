using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class Collectible : MonoBehaviour
{
    public int EffectValue { get; private set; }

    private Coroutine _coroutine;
    private CollectibleSpawner _collectibleSpawner;

    public void Initialize(CollectibleSpawner collectibleSpawner)
    {
        _collectibleSpawner = collectibleSpawner;
    }

    protected abstract void OnTriggerEnter2D(Collider2D collision);

    protected void Follow(Collector collector)
    {
        if (gameObject.activeSelf && _coroutine == null)
            _coroutine = StartCoroutine(FollowSmoothly(collector));
    }

    private IEnumerator FollowSmoothly(Collector collector)
    {
        float pickUpSpeed = 15;
        Vector3 targetPosition = collector.transform.position;

        while (transform.position != targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * pickUpSpeed);
            pickUpSpeed++;

            yield return null;
        }

        _collectibleSpawner.ReleaseCollectible(this);

        _coroutine = null;
    }

    protected void SetRandomEffectValue(int minValue, int maxValue)
    {
        EffectValue = Random.Range(minValue, maxValue);
    }
}