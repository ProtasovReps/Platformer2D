using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Fighter _fighter;
    [SerializeField] private CharacterMover _characterMover;
    [SerializeField] private Animator _animator;

    private AnimatorToggler _animatorToggler;

    public void Initialize()
    {
        _animatorToggler = new AnimatorToggler(_animator);

        _health.Initialize();
        _fighter.Initialize(_animatorToggler, _health);
        _characterMover.Initialize(_animatorToggler);

        _health.AmountChanged += Die;
    }

    private void Die()
    {
        if (_health.Value <= 0)
        {
            _characterMover.enabled = false;
            _fighter.enabled = false;
            _animatorToggler.SetDieBool();
        }
    }
}