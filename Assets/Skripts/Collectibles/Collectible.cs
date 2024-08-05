using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class Collectible :  PoolingObject
{
    [SerializeField, Min(1)] private int _minValue;
    [SerializeField, Min(1)] private int _maxValue;

    public override event Action<PoolingObject> ReadyToRelease;

    public int GetCollected(Vector3 targetPosition)
    {
        StartFollowingSmoothly(targetPosition);
        return GetRandomEffectValue();
    }

    private void StartFollowingSmoothly(Vector3 targetPosition) => StartCoroutine(FollowSmoothly(targetPosition));

    private int GetRandomEffectValue() => Random.Range(_minValue, _maxValue);

    private IEnumerator FollowSmoothly(Vector3 targetPosition)
    {
        float pickUpSpeed = 15;

        while (transform.position != targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * pickUpSpeed);
            pickUpSpeed++;
            yield return null;
        }

        ReadyToRelease?.Invoke(this);
    }
}