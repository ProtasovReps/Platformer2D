using System;

public class Wallet
{
    public event Action AmountChanged;

    public int CoinsCount { get; private set; }

    public void AddCoin()
    {
        CoinsCount++;
        AmountChanged?.Invoke();
    }
}
