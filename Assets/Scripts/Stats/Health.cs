using System;

public class Health : IRangeable, IValueIncreaseable, IValueDecreaseable
{
    private ArgumentChecker _argumentChecker;

    public Health(int maxValue)
    {
        MaxValue = maxValue;
        Revive();
        _argumentChecker = new ArgumentChecker();
    }

    public event Action ValueChanged;

    public float MaxValue { get; }
    public float Value { get; private set; }

    public void Revive()
    {
        Value = MaxValue;
        ValueChanged?.Invoke();
    }

    public void IncreaseValue(float healValue)
    {
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

    public void DecreaseValue(float damage)
    {
        if (_argumentChecker.CheckPositiveValue(damage))
        {
            Value -= damage;
            ValueChanged?.Invoke();
        }
    }
}