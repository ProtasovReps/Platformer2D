using System.Collections;
using UnityEngine;

public class Vampirism : MonoBehaviour
{
    [SerializeField, Min(1)] private float _stealTime = 6f;
    [SerializeField, Min(1)] private float _stealAmount = 1f;
    [SerializeField, Min(1)] private float _cooldownTime;
    [SerializeField] private Timer _timer;

    private Health _health;
    private Coroutine _coroutine;

    public void Initialize(Health health)
    {
        _health = health;
        _timer.Initialize();
    }

    public void StartStealingHealth(Enemy[] targetEnemies)
    {
        if (_coroutine == null && _timer.IsEnded)
        {
            _coroutine = StartCoroutine(StealHealth(targetEnemies));
        }
    }

    private IEnumerator StealHealth(Enemy[] targetEnemies)
    {
        float stealAmount = _stealAmount / targetEnemies.Length / _stealTime * Time.deltaTime;
        _timer.StartWaiting(_stealTime, false);

        while (_timer.IsEnded == false)
        {
            foreach (Enemy enemy in targetEnemies)
            {
                if (enemy.HealthRange.Value >= 0f)
                {
                    enemy.HealthDecreaseable.DecreaseValue(stealAmount);
                    _health.IncreaseValue(stealAmount);
                }
            }

            yield return null;
        }

        _timer.StartWaiting(_cooldownTime, true);
        _coroutine = null;
    }
}
