using UnityEngine;

public class Food : Collectible
{
    private int _minValue = 1;
    private int _maxValue = 5;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Health health))
        {
            Follow(health);
            ApplyEffect(health);
        }
    }

    protected override void ApplyEffect(Collector collector)
    {
        collector.Collect(Random.Range(_minValue, _maxValue));
    }
}
