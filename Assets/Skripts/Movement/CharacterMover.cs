using UnityEngine;

public abstract class CharacterMover : MonoBehaviour
{
    public abstract void Initialize(AnimatorToggler animatorToggler);

    protected abstract void Move();

    protected abstract void Rotate();
}
