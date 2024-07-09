using System.Collections;
using UnityEngine;

public class EnemyFighter : Fighter
{
    [SerializeField] private LayerChecker _playerChecker;
    [SerializeField] private EnemyVision _enemyVision;
    [SerializeField, Min(1)] private int _maxDamage;
    [SerializeField, Min(0.5f)] private float _attackDelay;

    private Health _health;
    private AnimatorToggler _animatorToggler;
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

        StopAttackDelayed();
    }

    public void Initialize(AnimatorToggler animatorToggler, Health health)
    {
        _delay = new WaitForSeconds(_attackDelay);
        _animatorToggler = animatorToggler;
        _health = health;
    }

    public override void TakeDamage(int value)
    {
        _animatorToggler.SetTakeHitTrigger();
        _health.TakeDamage(value);
    }

    protected override void Attack()
    {
        Collider2D collider = _playerChecker.CheckPlayer();

        _animatorToggler.SetAttackTrigger();

        if (collider != null)
        {
            if (collider.TryGetComponent(out PlayerFighter playerFighter))
            {
                playerFighter.TakeDamage(GetRandomDamage(_maxDamage));
            }
        }
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
            Attack();
            yield return _delay;
        }
    }
}
