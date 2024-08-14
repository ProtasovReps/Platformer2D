using UnityEngine;

[RequireComponent (typeof(Collider2D))]
public class Collector<T> : MonoBehaviour where T : Collectible
{
    private IValueIncreaseable _stat;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out T collectible))
            ApplyCollectibleEffect(collectible);
    }

    public void Initialize(IValueIncreaseable stat) => _stat = stat;

    private void ApplyCollectibleEffect(T collectible)
    {
        int increasementValue = collectible.GetCollected(transform.position);

        _stat.IncreaseValue(increasementValue);
    }
}
