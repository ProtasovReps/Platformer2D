using UnityEngine;

public class Fighter : MonoBehaviour
{
    [SerializeField, Min(1)] private int _minDamage;
    [SerializeField, Min(1)] private int _maxDamage;
    [SerializeField] private FighterRaycaster _fighterFinder;

    private Health _health;
    private Animator _animator;

    public virtual void Initialize(Health health, Animator animator)
    {
        _health = health;
        _animator = animator;
    }

    public virtual void TakeDamage(float damageValue)
    {
        _animator.SetTrigger(AnimatorParameters.TakeHit);
        _health.DecreaseValue(damageValue);
    }

    public virtual void AttackForward()
    {
        _animator.SetTrigger(AnimatorParameters.Attack);

        if (_fighterFinder.TryGetFighterByRaycast(out Fighter fighter))
            fighter.TakeDamage(Random.Range(_minDamage, _maxDamage));
    }
}