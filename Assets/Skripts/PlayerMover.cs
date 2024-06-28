using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private AnimatorToggler _animatorToggler;

    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private float _moveSpeed = 14f;
    private float _jumpForce = 20f;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Move();
        Jump();
        Rotate();
    }

    private void Move()
    {
        float distance = GetHorizontalDirection() * _moveSpeed * Time.deltaTime;

        _animatorToggler.SetRunBool(Convert.ToBoolean(distance));
        transform.Translate(Vector2.right * distance);
    }

    private void Rotate()
    {
        float direction = GetHorizontalDirection();

        if (direction > 0)
            _spriteRenderer.flipX = false;
        if (direction < 0)
            _spriteRenderer.flipX = true;
    }

    private void Jump()
    {
        bool isGrounded = _groundChecker.CheckGround();

        _animatorToggler.SetFallingBool(isGrounded == false);

        if (isGrounded && Input.GetButtonDown(Vertical))
        {
            _animatorToggler.SetJumpTrigger();
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }

    private float GetHorizontalDirection() => Input.GetAxisRaw(Horizontal);
}

