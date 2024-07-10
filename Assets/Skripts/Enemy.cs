using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private EnemyFighter _enemyFighter;
    [SerializeField] private EnemyMover _enemyMover;
    [SerializeField, Min(1)] private int _maxHealth;

    private AnimatorToggler _animatorToggler;
    private EnemySpawner _enemySpawner;
    private Health _health;

    public void Initialize(EnemySpawner enemySpawner)
    {
        _enemySpawner = enemySpawner;
        _health = new Health(_maxHealth);
        _animatorToggler = new AnimatorToggler(_animator);

        _enemyMover.Initialize(_animatorToggler);
        _enemyFighter.Initialize(_animatorToggler, _health);
        
        _health.Died += Die;
    }

    public void Revive()
    {
        _health.Revive();
        _animatorToggler.SetDieBool(false);
        _animatorToggler.SetRunBool(true);
    }

    private void Die()
    {
        _enemySpawner.ReleaseEnemy(this);
        _animatorToggler.SetDieBool(true);
    }
}
