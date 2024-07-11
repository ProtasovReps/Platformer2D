using UnityEngine;

[RequireComponent (typeof(Collider2D))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private EnemyFighter _enemyFighter;
    [SerializeField] private EnemyMovement _enemyMover;
    [SerializeField, Min(1)] private int _maxHealth;

    private EnemySpawner _enemySpawner;
    private Collider2D _collider2D;
    private Health _health;

    public void Initialize(EnemySpawner enemySpawner)
    {
        _enemySpawner = enemySpawner;
        _health = new Health(_maxHealth);
        _collider2D = GetComponent<Collider2D>();

        _enemyMover.Initialize(_animator);
        _enemyFighter.Initialize(_animator, _health);
        
        _health.Died += Release;
    }

    public void Revive()
    {
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
        _collider2D.attachedRigidbody.isKinematic = true;
        _collider2D.enabled = false;
        _enemyFighter.enabled = false;
        _enemyMover.enabled = false;

        _animator.SetBool(AnimatorConstants.IsDead.ToString(), true);
    }

    private void Release() => _enemySpawner.ReleaseEnemy(this);
}
