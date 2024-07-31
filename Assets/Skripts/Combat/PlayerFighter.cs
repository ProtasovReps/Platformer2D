using UnityEngine;

public class PlayerFighter : Fighter
{
    [SerializeField, Min(1)] private int _maxDamage;

    private Health _health;
    private Animator _animator;

    public int MaxDamage => _maxDamage;
   
    public void Initialize(Animator animator, Health health)
    {
        _animator = animator;
        _health = health;
    }

    public override void TakeDamage(int value)
    {
        _animator.SetTrigger(AnimatorConstants.TakeHit.ToString());
        _health.TakeDamage(value);
    }
}
