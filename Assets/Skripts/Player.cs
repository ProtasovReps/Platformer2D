using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerFighter _playerFighter;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private Animator _animator;
    [SerializeField, Min(1)] private int _maxHealth;

    private AnimatorToggler _animatorToggler;

    public Health Health { get; private set; }
    public Wallet Wallet { get; private set; }

    public void Initialize()
    {
        Health = new Health(_maxHealth);
        Wallet = new Wallet();
        _animatorToggler = new AnimatorToggler(_animator);

        _playerMover.Initialize(_animatorToggler);
        _playerFighter.Initialize(_animatorToggler, Health);

        Health.Died += Die;
    }

    private void Die()
    {
        _playerMover.enabled = false;
        _playerFighter.enabled = false;

        _animatorToggler.SetDieBool(true);
    }
}
