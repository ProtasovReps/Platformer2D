using UnityEngine;

public class EnemyMover : CharacterMover
{
    [SerializeField] private LayerChecker _groundChecker;
    [SerializeField] private float _moveSpeed;
     
    private AnimatorToggler _animatorToggler;

    public override void Initialize(AnimatorToggler animatorToggler)
    {
        _animatorToggler = animatorToggler;
        _animatorToggler.SetRunBool(true);
    }

    protected override void Move()
    {
        if (_groundChecker.CheckGround() == false)
            Rotate();

        transform.Translate(transform.right * _moveSpeed * Time.deltaTime, Space.World);
    }

    protected override void Rotate()
    {
        if (transform.rotation.y > 0)
            transform.rotation = Quaternion.Euler(Vector3.zero);
        else
            transform.rotation = Quaternion.Euler(new Vector3(0, 180));
    }

    private void Update() => Move();
}
