using UnityEngine;

public class TreatmentCollector : Collector
{
    private Health _health;

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Treatment treatment))
            _health.Heal(treatment, transform.position);
    }

    public void Initialize(Health health) => _health = health;
}
