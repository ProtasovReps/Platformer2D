using UnityEngine;

public abstract class Fighter : MonoBehaviour
{
    [SerializeField, Min(1)] private int _minDamage;
    [SerializeField, Min(1)] private int _maxDamage;
    [SerializeField] private FighterFinder _fighterFinder;

    private Health _health;
    private Animator _animator;

    public virtual void Initialize(Health health, Animator animator)
    {
        _health = health;
        _animator = animator;
    }

    public virtual void TakeDamage(int value)
    {
        _animator.SetTrigger(AnimatorData.Params.TakeHit);
        _health.TakeDamage(value);
    }

    public virtual void AttackForward()
    {
        _animator.SetTrigger(AnimatorData.Params.Attack);

        if (_fighterFinder.TryGetFighterByRaycast(out Fighter fighter))
            fighter.TakeDamage(Random.Range(_minDamage, _maxDamage));
    }
}