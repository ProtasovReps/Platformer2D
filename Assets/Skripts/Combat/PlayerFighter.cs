using UnityEngine;

public class PlayerFighter : Fighter
{
    [SerializeField] private LayerChecker _enemyCheker;
    [SerializeField] private int _maxDamage;

    private Health _health;
    private AnimatorToggler _animatorToggler;
   
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
            Attack();
    }

    public void Initialize(AnimatorToggler animatorToggler, Health health)
    {
        _animatorToggler = animatorToggler;
        _health = health;
    }

    public override void TakeDamage(int value)
    {
        _animatorToggler.SetTakeHitTrigger();
        _health.TakeDamage(value);
    }

    protected override void Attack()
    {
        Collider2D Collider = _enemyCheker.CheckEnemy();

        _animatorToggler.SetAttackTrigger();

        if (Collider != null)
        {
            if (Collider.TryGetComponent(out EnemyFighter enemyFighter))
            {
                enemyFighter.TakeDamage(GetRandomDamage(_maxDamage));
            }
        }
    }
}
