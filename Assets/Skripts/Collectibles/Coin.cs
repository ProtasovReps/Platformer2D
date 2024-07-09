using UnityEngine;

public class Coin : Collectible
{
    [SerializeField, Min(1)] private int _minCostValue = 1;
    [SerializeField, Min(1)] private int _maxCostValue = 3;
    
    public override CollectibleTypes Type => CollectibleTypes.Money;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            Follow(player);
            SetRandomEffectValue(_minCostValue, _maxCostValue);

            player.Wallet.Collect(this);
        }
    }
}