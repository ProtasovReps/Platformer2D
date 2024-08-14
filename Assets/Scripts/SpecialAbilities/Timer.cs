using System;
using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour, IRangeable
{
    private Coroutine _coroutine;

    public event Action ValueChanged;
    
    public float MaxValue => Value;
    public float Value { get; private set; }
    public bool IsEnded { get; private set; }

    public void Initialize() => IsEnded = true;

    public void StartWaiting(float waitTime, bool isStopwatch)
    {
        if (_coroutine == null)
        {
            IsEnded = false;
            _coroutine = StartCoroutine(Wait(waitTime, isStopwatch));
        }
    }

    private IEnumerator Wait(float waitTime, bool isStopwatch)
    {
        float elapsedTime = 0;

        while (elapsedTime < waitTime)
        {
            elapsedTime += Time.deltaTime;
            
            if(isStopwatch)
                Value = GetOccupiedPart(waitTime, elapsedTime);
            else
                Value = GetRemainingPart(waitTime, elapsedTime);

            ValueChanged?.Invoke();
            yield return null;
        }

        IsEnded = true;
        _coroutine = null;
    }

    private float GetOccupiedPart(float waitTime, float elapsedTime) => elapsedTime / waitTime;

    private float GetRemainingPart(float waitTime, float elapsedTime)
    {
        float hundredthPart = 100f;
        float occupiedPercent = elapsedTime / waitTime * hundredthPart;
        float remainingPercent = hundredthPart - occupiedPercent;
        
        return GetOccupiedPart(hundredthPart, remainingPercent);
    }
}
