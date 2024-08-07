using UnityEngine;

public static class AnimatorData
{
    public static class Params
    {
        public static readonly int IsRunning = Animator.StringToHash(nameof(IsRunning));
        public static readonly int IsFalling = Animator.StringToHash(nameof(IsFalling));
        public static readonly int Jump = Animator.StringToHash(nameof(Jump));
        public static readonly int Attack = Animator.StringToHash(nameof(Attack));
        public static readonly int TakeHit = Animator.StringToHash(nameof(TakeHit));
        public static readonly int IsDead = Animator.StringToHash(nameof(IsDead));
    }
}
