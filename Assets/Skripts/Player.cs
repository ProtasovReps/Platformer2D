using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private PlayerInteraction _playerInteraction;
    [SerializeField] private Animator _animator;
    [SerializeField, Min(1)] private int _maxHealth;

    public Health Health { get; private set; }
    public Wallet Wallet { get; private set; }

    public void Initialize()
    {
        Health = new Health(_maxHealth);
        Wallet = new Wallet();

        _playerInteraction.Initialize(_animator, Health);

        Health.Died += Die;
    }

    private void Die()
    {
        _playerInteraction.enabled = false;
        _animator.SetBool(AnimatorConstants.IsDead.ToString(), true);
    }
}
