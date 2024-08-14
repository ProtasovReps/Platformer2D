using System.Collections;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private PlayerFighter _playerFighter;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private AbilityPreview _abilityPreview;

    private Coroutine _coroutine;
    private WaitUntil _delay;

    public void Initialize(Animator animator, Health health)
    {
        _delay = new WaitUntil(() => _inputReader.IsSpecialAbility == false);
       
        _playerMovement.Initialize(animator);
        _playerFighter.Initialize(health, animator);
    }

    private void FixedUpdate()
    {
        if (_inputReader.HorizontalDirection != 0)
        {
            bool isGoingRight = _inputReader.HorizontalDirection > 0;

            _playerMovement.Rotate(isGoingRight);
            _playerMovement.Move(_inputReader.HorizontalDirection);
        }
        else
        {
            _playerMovement.Stay();
        }

        if (_inputReader.GetIsJumping() && _groundChecker.CheckGround())
        {
            _playerMovement.Jump();
        }

        if (_inputReader.GetIsForwardAttacking())
        {
            _playerFighter.AttackForward();
        }

        if (_inputReader.IsSpecialAbility)
        {
            if (_coroutine == null)
                _coroutine = StartCoroutine(ActivateAbilityWithPreview());
        }
    }

    private IEnumerator ActivateAbilityWithPreview()
    {
        _abilityPreview.ShowAbilityRange();
        yield return _delay;
        
        _abilityPreview.HideAbilityRange();
        _playerFighter.StealHealth();

        _coroutine = null;
    }
}
