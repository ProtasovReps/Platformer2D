using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    
    [SerializeField, Min(1)] private float _moveSpeed = 14f;
    [SerializeField, Min(1)] private float _jumpForce = 20f;
    [SerializeField] private LayerChecker _groundChecker;

    private AnimatorToggler _animatorToggler;
    private Rigidbody2D _rigidbody;
    private float _horizontalDirection;

    public void Initialize(AnimatorToggler animatorToggler)
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animatorToggler = animatorToggler;
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

        _animatorToggler.SetRunBool(Convert.ToBoolean(distance));
        transform.Translate(Vector2.right * distance, Space.World);
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
}