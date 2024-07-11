using System.Collections;
using UnityEngine;

public class EnemyFighter : Fighter
{
    [SerializeField] private ColliderFinder _colliderFinder;
    [SerializeField] private EnemyVision _enemyVision;
    [SerializeField, Min(1)] private int _maxDamage;
    [SerializeField, Min(0.5f)] private float _attackDelay;

    private Health _health;
    private Animator _animator;
    private Coroutine _coroutine;
    private WaitForSeconds _delay;

    private void OnEnable()
    {
        _enemyVision.PlayerFound += StartAttackDelayed;
        _enemyVision.PlayerLost += StopAttackDelayed;
    }

    private void OnDisable()
    {
        _enemyVision.PlayerFound -= StartAttackDelayed;
        _enemyVision.PlayerLost -= StopAttackDelayed;
    }

    public void Initialize(Animator animator, Health health)
    {
        _delay = new WaitForSeconds(_attackDelay);
        _animator = animator;
        _health = health;
    }

    public override void TakeDamage(int value)
    {
        _animator.SetTrigger(AnimatorConstants.TakeHit.ToString());
        _health.TakeDamage(value);
    }

    private void StartAttackDelayed()
    {
        if (gameObject.activeSelf)
            _coroutine = StartCoroutine(AttackDelayed());
    }

    private void StopAttackDelayed()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private IEnumerator AttackDelayed()
    {
        while (enabled)
        {
            Attack(_animator, _colliderFinder, _maxDamage);
            yield return _delay;
        }
    }
}
