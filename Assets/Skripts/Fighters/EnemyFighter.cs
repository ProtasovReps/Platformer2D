using System.Collections;
using UnityEngine;

public class EnemyFighter : Fighter
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

    public override void Initialize(Animator animator, Health health)
    {
        base.Initialize(animator, health);
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
            Attack();
            yield return _delay;
        }
    }
}
