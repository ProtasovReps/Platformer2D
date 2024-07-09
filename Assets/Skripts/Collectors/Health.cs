using System;
using UnityEngine;

public class Health : ICollector
{
    [SerializeField, Min(1)] private int _maxValue = 5;

    public Health()
    {
        Revive();
    }

    public event Action Died;

    public int Value { get; private set; }
    
    public void Revive() => Value = _maxValue;

    public void Collect(Collectible collectible)
    {
        if (collectible.EffectValue < 0)
            throw new ArgumentOutOfRangeException(nameof(collectible));
        
        if (collectible.Type == CollectibleTypes.Medicine)
            Value = Mathf.Clamp(Value, 0, _maxValue);
    }

    public void TakeDamage(int damage)
    {
        if (damage < 0)
            throw new ArgumentOutOfRangeException(nameof(damage));

        Value -= damage;

        if (Value <= 0)
            Died?.Invoke();
    }
}