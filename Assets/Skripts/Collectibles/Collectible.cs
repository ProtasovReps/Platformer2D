using System;
using System.Collections;
using UnityEngine;

public abstract class Collectible : MonoBehaviour
{
    [SerializeField] private int _minValue;
    [SerializeField] private int _maxValue;

    public event Action<Collectible> PickedUp;

    public int GetCollected(Vector3 targetPosition)
    {
        StartFollowingSmoothly(targetPosition);
        return GetRandomEffectValue();
    }

    private void StartFollowingSmoothly(Vector3 targetPosition) => StartCoroutine(FollowSmoothly(targetPosition));

    private int GetRandomEffectValue() => UnityEngine.Random.Range(_minValue, _maxValue);

    private IEnumerator FollowSmoothly(Vector3 targetPosition)
    {
        float pickUpSpeed = 15;

        while (transform.position != targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * pickUpSpeed);
            pickUpSpeed++;
            yield return null;
        }

        PickedUp?.Invoke(this);
    }
}