using UnityEngine;

public class Fighter : MonoBehaviour
{
    [SerializeField] private LayerChecker _layerCheker;
    [SerializeField] private int _maxDamage;

    private Health _health;
    private AnimatorToggler _animatorToggler;

    public void Initialize(AnimatorToggler animatorToggler, Health health)
    {
        _animatorToggler = animatorToggler;
        _health = health;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
            Attack();
    }

    private void Attack()
    {
        Collider2D enemy = _layerCheker.CheckEnemies();

        _animatorToggler.SetAttackTrigger();

        if (enemy != null)
        {
            if (enemy.TryGetComponent(out Fighter fighter))
            {
                fighter.TakeDamage(CalculateRandomDamage());
            }
        }
    }

    private void TakeDamage(int value)
    {
        _animatorToggler.SetTakeHitTrigger();
        _health.TakeDamage(value);
    }

    private int CalculateRandomDamage() => Random.Range(1, _maxDamage);
}
