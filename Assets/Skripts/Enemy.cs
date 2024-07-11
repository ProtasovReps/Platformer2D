using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private EnemyFighter _enemyFighter;
    [SerializeField] private EnemyMovement _enemyMover;
    [SerializeField, Min(1)] private int _maxHealth;

    private EnemySpawner _enemySpawner;
    private Health _health;

    public void Initialize(EnemySpawner enemySpawner)
    {
        _enemySpawner = enemySpawner;
        _health = new Health(_maxHealth);

        _enemyMover.Initialize(_animator);
        _enemyFighter.Initialize(_animator, _health);
        
        _health.Died += Die;
    }

    public void Revive()
    {
        _health.Revive();
        _animator.SetBool(AnimatorConstants.IsDead.ToString(), false);
        _animator.SetBool(AnimatorConstants.IsRunning.ToString(), true);
    }

    private void Die()
    {
        _enemySpawner.ReleaseEnemy(this);
        _animator.SetBool(AnimatorConstants.IsDead.ToString(), true);
    }
}
