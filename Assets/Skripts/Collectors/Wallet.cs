using System;
using UnityEngine;

public class Wallet
{
    private ArgumentChecker _argumentChecker;

    public Wallet() 
    { 
        _argumentChecker = new ArgumentChecker();
    }

    public event Action AmountChanged;

    public int Value { get; private set; }

    public void Collect(Money money, Vector3 parentPosition)
    {
        int moneyCount = money.GetCollected(parentPosition);

        if (_argumentChecker.CheckPositiveValue(moneyCount))
        {
            Value += moneyCount;
            AmountChanged?.Invoke();
        }
    }
}