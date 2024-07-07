using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Fighter _fighter;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private Animator _animator;

    private AnimatorToggler _animatorToggler;

    public void Initialize()
    {
        _animatorToggler = new AnimatorToggler(_animator);

        _health.Initialize();
        _fighter.Initialize(_animatorToggler, _health);
        _playerMover.Initialize(_animatorToggler);

        _health.AmountChanged += Die;
    }

    private void Die()
    {
        if (_health.Value <= 0)
        {
            _playerMover.enabled = false;
            _fighter.enabled = false;
            _animatorToggler.SetDieBool();
        }
    }
}
