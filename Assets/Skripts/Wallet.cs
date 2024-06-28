using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    public event Action AmountChanged;

    public int CoinsCount { get; private set; }

    public void AddCoin()
    {
        CoinsCount++;
        AmountChanged?.Invoke();
    }
}
