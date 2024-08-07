using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class Collectible :  PoolingObject
{
    [SerializeField, Min(1)] private int _minValue;
    [SerializeField, Min(1)] private int _maxValue;
    [SerializeField, Min(1)] private float _pickUpSpeed;

    public override event Action<PoolingObject> WorkedOut;

    public int GetCollected(Vector3 targetPosition)
    {
        StartFollowingSmoothly(targetPosition);
        return GetRandomEffectValue();
    }

    private void StartFollowingSmoothly(Vector3 targetPosition) => StartCoroutine(FollowSmoothly(targetPosition));

    private int GetRandomEffectValue() => Random.Range(_minValue, _maxValue);

    private IEnumerator FollowSmoothly(Vector3 targetPosition)
    {
        while (transform.position != targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * _pickUpSpeed);
            yield return null;
        }

        WorkedOut?.Invoke(this);
    }
}