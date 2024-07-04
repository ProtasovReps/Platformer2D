using UnityEngine;

public class AnimatorToggler 
{
    private Animator _animator;

    public AnimatorToggler(Animator animator)
    {
        _animator = animator;
    }

    public void SetAttackTrigger() => _animator.SetTrigger(AnimatorConstants.Attack.ToString());

    public void SetJumpTrigger() => _animator.SetTrigger(AnimatorConstants.Jump.ToString());

    public void SetRunBool(bool isRunning) => _animator.SetBool(AnimatorConstants.IsRunning.ToString(), isRunning);

    public void SetFallingBool(bool isFalling) => _animator.SetBool(AnimatorConstants.IsFalling.ToString(), isFalling);
}
