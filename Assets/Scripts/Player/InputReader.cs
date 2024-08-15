using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    private bool _isJumping;
    private bool _isAttackingForward;
    private bool _isSpecialAbility;

    public float HorizontalDirection {  get; private set; }

    private void Update()
    {
        HorizontalDirection = Input.GetAxisRaw(Horizontal);

        if (Input.GetKeyDown(KeyCode.UpArrow))
            _isJumping = true;

        if(Input.GetKeyDown(KeyCode.LeftControl))
            _isAttackingForward = true;

        if (Input.GetKeyDown(KeyCode.LeftAlt))
            _isSpecialAbility = true;
    }

    public bool GetIsJumping() => GetBoolAsTrigger(ref _isJumping);
    
    public bool GetIsForwardAttacking() => GetBoolAsTrigger(ref _isAttackingForward);

    public bool GetIsSpecialAbility() => GetBoolAsTrigger(ref _isSpecialAbility);

    private bool GetBoolAsTrigger(ref bool value)
    {
        bool localValue = value;
        value = false;
        return localValue;
    }
}
