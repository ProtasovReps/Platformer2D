using System;
using UnityEngine;

public class Health : Collector
{
    [SerializeField] private int _maxValue = 5;
   
    public override event Action AmountChanged;

    public void Initialize()
    {
        Revive();
        _maxValue = Value;
    }

    public void Revive() => Value = _maxValue;

    public override void Collect(Collectible collectible)
    {
        base.Collect(collectible);
        Value = Mathf.Clamp(Value, 0, _maxValue);
        AmountChanged?.Invoke();
    }

    public void TakeDamage(int damage)
    {
        Value -= damage;
        AmountChanged?.Invoke();
    }
}