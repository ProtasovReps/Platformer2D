using UnityEngine;

public class Food : Collectible
{
    private int _minHealValue = 1;
    private int _maxHealValue = 5;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Health health))
        {
            Follow(health);
            SetRandomEffectValue(_minHealValue, _maxHealValue);
            health.Collect(this);
        }
    }
}
