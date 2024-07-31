using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private PlayerFighter _playerFighter;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private ColliderFinder _colliderFinder;
    [SerializeField] private InputReader _inputReader;

    private Animator _animator;

    public void Initialize(Animator animator, Health health)
    {
        _animator = animator;

        _playerMovement.Initialize(_animator);
        _playerFighter.Initialize(_animator, health);
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

        if (_inputReader.GetIsAttacking())
        {
            _playerFighter.Attack(_animator, _colliderFinder, _playerFighter.MaxDamage);
        }
    }
}
