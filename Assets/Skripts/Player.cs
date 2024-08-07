using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private PlayerInteraction _playerInteraction;
    [SerializeField] private TreatmentCollector _treatmentCollector;
    [SerializeField] private MoneyCollector _moneyCollector;
    [SerializeField] private Animator _animator;
    [SerializeField, Min(1)] private int _maxHealth;

    private Health _health;
    private Wallet _wallet;

    public void Initialize()
    {
        _health = new Health(_maxHealth);
        _wallet = new Wallet();

        _playerInteraction.Initialize(_animator, _health);
        _treatmentCollector.Initialize(_health);
        _moneyCollector.Initialize(_wallet);

        _health.ValueChanged += CheckDeath;
    }
    
    public IRangeable GetWalletAsRangeable() => _wallet; 

    public IRangeable GetHealthAsRangeable() => _health; 

    private void CheckDeath()
    {
        int deathHealthValue = 0;

        if (_health.Value <= deathHealthValue)
        {
            _playerInteraction.enabled = false;
            _animator.SetBool(AnimatorData.Params.IsDead, true);
        }
    }
}
