using UnityEngine;

public abstract class Fighter : MonoBehaviour
{
    [SerializeField, Min(1)] private int _minDamage;
    [SerializeField, Min(1)] private int _maxDamage;
    [SerializeField] private ColliderFinder _colliderFinder;

    private Animator _animator;
    private Health _health;

    public virtual void Initialize(Animator animator, Health health)
    {
        _animator = animator;
        _health = health;
    }

    public virtual void TakeDamage(int value)
    {
        _animator.SetTrigger(AnimatorConstants.TakeHit.ToString());
        _health.TakeDamage(value);
    }

    public void Attack()
    {
        if (_colliderFinder.TryGetCollider(out Collider2D collider))
        {
            if (collider.TryGetComponent(out Fighter fighter))
            {
                if (fighter.isActiveAndEnabled)
                {
                    fighter.TakeDamage(Random.Range(_minDamage, _maxDamage));
                }
            }
        }

        _animator.SetTrigger(AnimatorConstants.Attack.ToString());
    }
}