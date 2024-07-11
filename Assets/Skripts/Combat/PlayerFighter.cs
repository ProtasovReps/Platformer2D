using UnityEngine;

public class PlayerFighter : Fighter
{
    [SerializeField] private ColliderFinder _colliderFinder;
    [SerializeField] private int _maxDamage;

    private Health _health;
    private Animator _animator;
   
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
            Attack(_animator, _colliderFinder, _maxDamage);
    }

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
