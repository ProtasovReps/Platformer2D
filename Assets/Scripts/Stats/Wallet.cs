using System;

public class Wallet : IRangeable, IValueIncreaseable
{
    private ArgumentChecker _argumentChecker;

    public Wallet() 
    { 
        _argumentChecker = new ArgumentChecker();
    }

    public event Action ValueChanged;

    public float MaxValue => Value;
    public float Value { get; private set; }

    public void IncreaseValue(float moneyValue)
    {
        if (_argumentChecker.CheckPositiveValue(moneyValue))
        {
            Value += moneyValue;
            ValueChanged?.Invoke();
        }
    }
}