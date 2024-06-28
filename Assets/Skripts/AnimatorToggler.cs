using UnityEngine;

public class AnimatorToggler : MonoBehaviour 
{
    [SerializeField] private Animator _animator;

    public void SetAttackTrigger() => _animator.SetTrigger(AnimatorConstants.Attack.ToString());

    public void SetJumpTrigger() => _animator.SetTrigger(AnimatorConstants.Jump.ToString());

    public void SetRunBool(bool isRunning) => _animator.SetBool(AnimatorConstants.IsRunning.ToString(), isRunning);

    public void SetFallingBool(bool isFalling) => _animator.SetBool(AnimatorConstants.IsFalling.ToString(), isFalling);
}
