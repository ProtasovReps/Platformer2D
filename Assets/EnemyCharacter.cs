using UnityEngine;

public class EnemyCharacter : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Fighter _fighter;
    [SerializeField] private EnemyMover _enemyMover;
    [SerializeField] private Animator _animator;

    private AnimatorToggler _animatorToggler;
    private EnemySpawner _enemySpawner;

    public void Initialize(EnemySpawner enemySpawner)
    {
        _enemySpawner = enemySpawner;
        _health.Initialize();
        _animatorToggler = new AnimatorToggler(_animator);
        _enemyMover.Initialize(_animatorToggler);
        _fighter.Initialize(_animatorToggler, _health);

        _health.AmountChanged += Die;
    }

    public void Revive()
    {
        _health.Revive();
        _animatorToggler.SetDieBool(false);
        _animatorToggler.SetRunBool(true);
        _enemyMover.enabled = true;
        _fighter.enabled = true;
    }

    private void Die()
    {
        if (_health.Value <= 0)
        {
            _enemyMover.enabled = false;
            _fighter.enabled = false;

            _animatorToggler.SetDieBool(true);
            _enemySpawner.ReleaseEnemy(this);
        }
    }
}
