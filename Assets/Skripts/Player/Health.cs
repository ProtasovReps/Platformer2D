using System;
using UnityEngine;

public class Health : Collector
{
    private int _maxValue;
    public override event Action AmountChanged;

    public void Initialize()
    {
        Value = 5;
        _maxValue = Value;
    }

    public override void Collect(int value)
    {
        Value += value;
        Value = Mathf.Clamp(Value, 0, _maxValue);
        AmountChanged?.Invoke();
    }

    public void TakeDamage(int damage)
    {
        Value -= damage;
        AmountChanged?.Invoke();
    }
}