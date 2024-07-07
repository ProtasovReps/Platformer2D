using System;

public class Wallet : Collector
{
    public override event Action AmountChanged;

    public override void Collect(Collectible collectible)
    {
        base.Collect(collectible);
        AmountChanged?.Invoke();
    }
}