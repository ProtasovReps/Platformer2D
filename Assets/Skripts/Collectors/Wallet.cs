using System;
using UnityEngine;

public class Wallet : IRangeable
{
    private ArgumentChecker _argumentChecker;

    public Wallet() 
    { 
        _argumentChecker = new ArgumentChecker();
    }

    public event Action ValueChanged;

    public int MaxValue => Value;
    public int Value { get; private set; }

    public void Collect(Money money, Vector3 parentPosition)
    {
        int moneyCount = money.GetCollected(parentPosition);

        if (_argumentChecker.CheckPositiveValue(moneyCount))
        {
            Value += moneyCount;
            ValueChanged?.Invoke();
        }
    }
}