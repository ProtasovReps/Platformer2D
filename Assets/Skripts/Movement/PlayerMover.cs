using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : CharacterMover
{
    private const string Horizontal = nameof(Horizontal);
    
    [SerializeField] private LayerChecker _groundChecker;
    [SerializeField] private float _moveSpeed = 14f;
    [SerializeField] private float _jumpForce = 20f;

    private AnimatorToggler _animatorToggler;
    private Rigidbody2D _rigidbody;

    public override void Initialize(AnimatorToggler animatorToggler)
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animatorToggler = animatorToggler;
    }

    private void Update()
    {
        Move();
        Jump();
        Rotate();
    }

    protected override void Move()
    {
        float distance = GetHorizontalDirection() * _moveSpeed * Time.deltaTime;

        _animatorToggler.SetRunBool(Convert.ToBoolean(distance));
        transform.Translate(Vector2.right * distance, Space.World);
    }

    protected override void Rotate()
    {
        float direction = GetHorizontalDirection();

        if (direction > 0)
            transform.rotation = Quaternion.Euler(Vector3.zero);

        if (direction < 0)
            transform.rotation = Quaternion.Euler(0, 180f, 0);
    }

    private void Jump()
    {
        bool isGrounded = _groundChecker.CheckGround();

        _animatorToggler.SetFallingBool(isGrounded == false);

        if (isGrounded && Input.GetKeyDown(KeyCode.UpArrow))
        {
            _animatorToggler.SetJumpTrigger();
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }

    private float GetHorizontalDirection() => Input.GetAxisRaw(Horizontal);
}