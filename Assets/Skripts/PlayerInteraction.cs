using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private PlayerFighter _playerFighter;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private InputReader _inputReader;

    public void Initialize(Animator animator, Health health)
    {
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
    }
}
