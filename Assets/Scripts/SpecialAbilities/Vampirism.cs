using System;
using System.Collections;
using UnityEngine;

public class Vampirism : MonoBehaviour
{
    [SerializeField] private EnemyCapsuleSearcher _enemySearcher;
    [SerializeField] private Timer _timer;
    [SerializeField, Min(1)] private float _stealTime = 6f;
    [SerializeField, Min(1)] private float _stealAmount = 1f;
    [SerializeField, Min(1)] private float _cooldownTime;

    private Health _health;
    private ClosestEnemySearcher _closestEnemySearcher;
    private Coroutine _coroutine;

    public event Action Started; 
    public event Action Ended;

    public void Initialize(Health health)
    {
        _health = health;
        _timer.Initialize();
        _closestEnemySearcher = new ClosestEnemySearcher();
    }

    public void StartStealingHealth()
    {
        if (_coroutine == null && _timer.IsEnded)
        {
            _coroutine = StartCoroutine(StealHealth());
        }
    }

    private IEnumerator StealHealth()
    {
        Started?.Invoke();
        _timer.StartWaiting(_stealTime, false);

        while (_timer.IsEnded == false)
        {
            if (_enemySearcher.TryGetEnemyByCapsulecast(out Enemy[] enemies))
            {
                Enemy targetEnemy = _closestEnemySearcher.GetClosestEnemy(transform.position, enemies);
                float stealAmount = _stealAmount / _stealTime * Time.deltaTime;

                if (targetEnemy.HealthRange.Value <= _stealAmount)
                {
                    stealAmount *= targetEnemy.HealthRange.Value / _stealAmount;
                }

                targetEnemy.HealthDecreaseable.DecreaseValue(stealAmount);
                _health.IncreaseValue(stealAmount);
            }

            yield return null;
        }

        Ended?.Invoke();
        _timer.StartWaiting(_cooldownTime, true);
        _coroutine = null;
    }
}
