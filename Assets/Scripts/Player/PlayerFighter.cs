using UnityEngine;

public class PlayerFighter : Fighter
{
    [SerializeField] private Vampirism _vampirism;

    private Health _health;

    public override void Initialize(Health health, Animator animator)
    {
        base.Initialize(health, animator);
        _health = health;
        _vampirism.Initialize(health);
    }

    public void StealHealth()
    {
        if (_health.Value < _health.MaxValue)
            _vampirism.StartStealingHealth();
    }
}
