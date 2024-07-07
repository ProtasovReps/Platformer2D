using UnityEngine;

public class Coin : Collectible
{
    private int _minValue = 1;
    private int _maxValue = 3;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Wallet wallet))
        {
            Follow(wallet);
            ApplyEffect(wallet);
        }
    }

    protected override void ApplyEffect(Collector collector)
    {
        collector.Collect(Random.Range(_minValue, _maxValue));
    }
}