using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Fighter _fighter;
    [SerializeField] private EnemyMover _enemyMover;
    [SerializeField] private Animator _animator;

    private AnimatorToggler _animatorToggler;

    private void Awake() => Initialize();

    private void Initialize()
    {
        _animatorToggler = new AnimatorToggler(_animator);
        
        _health.Initialize();
        _fighter.Initialize(_animatorToggler, _health);
        _enemyMover.Initialize(_animatorToggler);

        _health.AmountChanged += Die;
    }

    private void Die()
    {
        _enemyMover.enabled = false;
        _fighter.enabled = false;
        _animatorToggler.SetDieBool();
    }
}
