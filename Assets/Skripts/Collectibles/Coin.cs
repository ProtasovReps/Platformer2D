using UnityEngine;

public class Coin : Collectible
{
    private int _minCostValue = 1;
    private int _maxCostValue = 3;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Wallet wallet))
        {
            Follow(wallet);
            SetRandomEffectValue(_minCostValue, _maxCostValue);
            wallet.Collect(this);
        }
    }
}