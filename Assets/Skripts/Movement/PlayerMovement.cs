using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    
    [SerializeField, Min(1)] private float _moveSpeed = 14f;
    [SerializeField, Min(1)] private float _jumpForce = 20f;
    [SerializeField] private GroundChecker _groundChecker;

    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private float _horizontalDirection;

    public void Initialize(Animator animator)
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = animator;
    }

    private void Update()
    {
        _horizontalDirection = Input.GetAxisRaw(Horizontal);

        Move();
        Jump();
        Rotate();
    }

    private void Rotate()
    {
        if (_horizontalDirection > 0)
            transform.rotation = Quaternion.Euler(Vector3.zero);

        if (_horizontalDirection < 0)
            transform.rotation = Quaternion.Euler(0, 180f, 0);
    }

    private void Move()
    {
        float distance = _horizontalDirection * _moveSpeed * Time.deltaTime;

        _animator.SetBool(AnimatorConstants.IsRunning.ToString(), Convert.ToBoolean(distance));
        transform.Translate(Vector2.right * distance, Space.World);
    }

    private void Jump()
    {
        bool isGrounded = _groundChecker.CheckGround();

        _animator.SetBool(AnimatorConstants.IsFalling.ToString(), isGrounded == false);

        if (isGrounded && Input.GetKeyDown(KeyCode.UpArrow))
        {
            _animator.SetTrigger(AnimatorConstants.Jump.ToString());
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }
}