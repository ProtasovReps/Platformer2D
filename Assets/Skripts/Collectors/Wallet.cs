using System;

public class Wallet : ICollector
{
    public event Action AmountChanged;

    public int Value { get; private set; }

    public void Collect(Collectible collectible)
    {
        if (collectible.EffectValue < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(collectible));
        }
        else if (collectible.Type == CollectibleTypes.Money)
        {
            Value += collectible.EffectValue;
            AmountChanged?.Invoke();
        }
    }
}