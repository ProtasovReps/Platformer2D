using System.Collections;
using UnityEngine;

public class SkeletonFighter : Fighter
{
    [SerializeField] private EnemyVision _enemyVision;
    [SerializeField, Min(0.5f)] private float _attackDelay;

    private Coroutine _coroutine;
    private WaitForSeconds _delay;

    private void OnEnable()
    {
        _enemyVision.FighterSeen += StartAttackDelayed;
        _enemyVision.FighterLost += StopAttackDelayed;
    }

    private void OnDisable()
    {
        _enemyVision.FighterSeen -= StartAttackDelayed;
        _enemyVision.FighterLost -= StopAttackDelayed;

        StopAttackDelayed();
    }

    public override void Initialize(Health health, Animator animator)
    {
        base.Initialize(health, animator);
        _delay = new WaitForSeconds(_attackDelay);
    }

    private void StartAttackDelayed(Fighter fighter)
    {
        if (gameObject.activeSelf && fighter != null)
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
            AttackForward();

            yield return _delay;
        }
    }
}
