using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    private bool _isJumping;
    private bool _isAttackingForward;

    public bool IsSpecialAbility { get; private set; }
    public float HorizontalDirection {  get; private set; }

    private void Update()
    {
        HorizontalDirection = Input.GetAxisRaw(Horizontal);

        if (Input.GetKeyDown(KeyCode.UpArrow))
            _isJumping = true;

        if(Input.GetKeyDown(KeyCode.LeftControl))
            _isAttackingForward = true;

        if (Input.GetKeyDown(KeyCode.LeftAlt))
            IsSpecialAbility = true;

        if (Input.GetKeyUp(KeyCode.LeftAlt))
            IsSpecialAbility = false;
    }

    public bool GetIsJumping() => GetBoolAsTrigger(ref _isJumping);
    
    public bool GetIsForwardAttacking() => GetBoolAsTrigger(ref _isAttackingForward);

    private bool GetBoolAsTrigger(ref bool value)
    {
        bool localValue = value;
        value = false;
        return localValue;
    }
}
