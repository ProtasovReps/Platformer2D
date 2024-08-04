using System;
using System.Collections;
using UnityEngine;

public abstract class Collectible : MonoBehaviour
{
    private Coroutine _coroutine;

    public event Action<Collectible> PickedUp;

    public abstract CollectibleTypes Type { get; }
    public int EffectValue { get; private set; }

    protected abstract void OnTriggerEnter2D(Collider2D collision);

    protected void Follow(Player player)
    {
        _coroutine = StartCoroutine(FollowSmoothly(player));
    }

    protected void SetRandomEffectValue(int minValue, int maxValue)
    {
        int randomEffectValue = UnityEngine.Random.Range(minValue, maxValue);

        if (randomEffectValue < 0)
            throw new ArgumentOutOfRangeException(nameof(randomEffectValue));

        EffectValue = randomEffectValue;
    }

    private IEnumerator FollowSmoothly(Player player)
    {
        float pickUpSpeed = 15;
        Vector3 targetPosition = player.transform.position;

        while (transform.position != targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * pickUpSpeed);
            pickUpSpeed++;
            yield return null;
        }

        PickedUp?.Invoke(this);
    }
}