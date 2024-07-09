using UnityEngine;

public class Food : Collectible
{
    [SerializeField, Min(1)] private int _minHealValue = 1;
    [SerializeField, Min(1)] private int _maxHealValue = 5;

    public override CollectibleTypes Type => CollectibleTypes.Medicine;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            Follow(player);
            SetRandomEffectValue(_minHealValue, _maxHealValue);

            player.Health.Collect(this);
        }
    }
}
