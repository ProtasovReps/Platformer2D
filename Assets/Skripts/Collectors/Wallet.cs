using System;

public class Wallet : Collector
{
    public override event Action AmountChanged;

    public override void Collect(int value)
    {
        Value += value;
        AmountChanged?.Invoke();
    }
}