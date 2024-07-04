using UnityEngine;

public class Food : Collectible
{
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Collector collector))
            collector.Heal(this);
    }
}
