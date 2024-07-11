using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerFighter _playerFighter;
    [SerializeField] private PlayerMovement _playerMover;
    [SerializeField] private Animator _animator;
    [SerializeField, Min(1)] private int _maxHealth;

    public Health Health { get; private set; }
    public Wallet Wallet { get; private set; }

    public void Initialize()
    {
        Health = new Health(_maxHealth);
        Wallet = new Wallet();

        _playerMover.Initialize(_animator);
        _playerFighter.Initialize(_animator, Health);

        Health.Died += Die;
    }

    private void Die()
    {
        _playerMover.enabled = false;
        _playerFighter.enabled = false;

        _animator.SetBool(AnimatorConstants.IsDead.ToString(), true);
    }
}
