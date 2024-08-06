using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField, Min(1)] private float _moveSpeed = 14f;
    [SerializeField, Min(1)] private float _jumpForce = 20f;

    private Animator _animator;
    private Rigidbody2D _rigidbody;

    public void Initialize(Animator animator)
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = animator;
    }

    public void Rotate(bool isGoingRight)
    {
        if (isGoingRight)
            transform.rotation = Quaternion.Euler(Vector3.zero);
        else
            transform.rotation = Quaternion.Euler(0, 180f, 0);
    }

    public void Move(float direction)
    {
        float distance = direction * _moveSpeed * Time.fixedDeltaTime;

        _animator.SetBool(AnimatorConstants.IsRunning.ToString(), true);
        transform.Translate(Vector2.right * distance, Space.World);
    }

    public void Stay()
    {
        _animator.SetBool(AnimatorConstants.IsRunning.ToString(), false);
    }

    public void Jump()
    {
        _animator.SetTrigger(AnimatorConstants.Jump.ToString());
        _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }
}