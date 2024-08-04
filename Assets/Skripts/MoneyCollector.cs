using UnityEngine;

public class MoneyCollector : Collector
{
    private Wallet _wallet;

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Money money))
            _wallet.Collect(money, CollectPoint);
    }

    public void Initialize(Wallet wallet)
    {
        _wallet = wallet;
    }
}
