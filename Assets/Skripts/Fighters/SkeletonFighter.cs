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
        _enemyVision.FighterSeen += ChooseAction;
    }

    private void OnDisable()
    {
        _enemyVision.FighterSeen -= ChooseAction;

        StopAttackDelayed();
    }

    public override void Initialize(Health health, Animator animator)
    {
        base.Initialize(health, animator);
        _delay = new WaitForSeconds(_attackDelay);
    }

    private void ChooseAction(bool isPlayerSeen)
    {
        if (isPlayerSeen)
            StartAttackDelayed();
        else
            StopAttackDelayed();
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
                AttackForward();

            yield return _delay;
        }
    }
}
