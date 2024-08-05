using System;
using UnityEngine;

public class Health : IRangeable
{
    private ArgumentChecker _argumentChecker;

    public Health(int maxValue)
    {
        MaxValue = maxValue;
        Revive();
        _argumentChecker = new ArgumentChecker();
    }

    public event Action ValueChanged;

    public int MaxValue { get; }
    public int Value { get; private set; }

    public void Revive()
    {
        Value = MaxValue;
        ValueChanged?.Invoke();
    }

    public void Heal(Treatment treatment, Vector3 parentPosition)
    {
        int healValue = treatment.GetCollected(parentPosition);

        if (_argumentChecker.CheckPositiveValue(healValue))
        {
            if (_argumentChecker.CheckRange(Value, healValue, MaxValue))
            {
                Value = MaxValue;
            }
            else
            {
                Value += healValue;
            }

            ValueChanged?.Invoke();
        }
    }

    public void TakeDamage(int damage)
    {
        if (_argumentChecker.CheckPositiveValue(damage))
        {
            Value -= damage;
            ValueChanged?.Invoke();
        }
    }
}