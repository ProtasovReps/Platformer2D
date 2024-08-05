using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private EnemyFighter _enemyFighter;
    [SerializeField] private EnemyMovement _enemyMover;
    [SerializeField, Min(1)] private int _maxHealth;

    private Collider2D _collider2D;
    private Health _health;

    public event Action<Enemy> Died;

    private void OnEnable()
    {
        if (_health != null)
            _health.ValueChanged += CheckHealth;
    }

    private void OnDisable()
    {
        if (_health != null)
            _health.ValueChanged -= CheckHealth;
    }

    public void Initialize()
    {
        _health = new Health(_maxHealth);
        _collider2D = GetComponent<Collider2D>();

        _enemyMover.Initialize(_animator);
        _enemyFighter.Initialize(_animator, _health);

        _health.ValueChanged += CheckHealth;
    }

    public void Revive()
    {
        enabled = true;
        _health.Revive();

        _collider2D.attachedRigidbody.isKinematic = false;
        _collider2D.enabled = true;
        _enemyFighter.enabled = true;
        _enemyMover.enabled = true;

        _animator.SetBool(AnimatorConstants.IsDead.ToString(), false);
        _animator.SetBool(AnimatorConstants.IsRunning.ToString(), true);
    }

    public void Die()
    {
        enabled = false;
        _enemyFighter.enabled = false;
        _collider2D.attachedRigidbody.isKinematic = true;
        _collider2D.enabled = false;
        _enemyMover.enabled = false;

        _animator.SetBool(AnimatorConstants.IsDead.ToString(), true);
    }

    private void CheckHealth()
    {
        int deadHealthValue = 0;

        if (_health.Value <= deadHealthValue)
            Died?.Invoke(this);
    }
}
