using UnityEngine;

public class Coin : Collectible
{
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Collector collector))
            collector.AddMoney(this);
    }
}
