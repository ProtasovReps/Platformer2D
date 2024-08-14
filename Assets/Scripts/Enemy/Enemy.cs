using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Enemy : PoolingObject
{
    [SerializeField] private Animator _animator;
    [SerializeField] private EnemyFighter _enemyFighter;
    [SerializeField] private EnemyMovement _enemyMover;
    [SerializeField] private Transform _worldHealthViewTarget;
    [SerializeField] private WorldStatView _worldHealthView;
    [SerializeField, Min(1)] private int _maxHealth;

    private Collider2D _collider2D;
    private Health _health;

    public override event Action<PoolingObject> WorkedOut;

    public IRangeable HealthRange => _health;
    public IValueDecreaseable HealthDecreaseable => _health;

    private void Awake() => Initialize();

    public override void Appear()
    {
        _health.ValueChanged += CheckHealth;
        _health.Revive();

        SwitchState(true);

        _animator.SetBool(AnimatorParameters.IsDead, false);
        _animator.SetBool(AnimatorParameters.IsRunning, true);
    }

    public override void Release()
    {
        _health.ValueChanged -= CheckHealth;

        _animator.SetBool(AnimatorParameters.IsDead, true);
        SwitchState(false);
    }

    private void SwitchState(bool isAlive)
    {
        _collider2D.enabled = isAlive;
        _enemyFighter.enabled = isAlive;
        _enemyMover.enabled = isAlive;
        _collider2D.attachedRigidbody.isKinematic = isAlive == false;
    }

    private void Initialize()
    {
        WorldStatView worldHealthView = Instantiate(_worldHealthView);
        _health = new Health(_maxHealth);
        _collider2D = GetComponent<Collider2D>();

        worldHealthView.Initialize(_health, _worldHealthViewTarget);
        _enemyMover.Initialize(_animator);
        _enemyFighter.Initialize(_health, _animator);
    }

    private void CheckHealth()
    {
        int deadHealthValue = 0;

        if (_health.Value <= deadHealthValue)
            WorkedOut?.Invoke(this);
    }
}
