using UnityEngine;

public abstract class Fighter : MonoBehaviour
{
    public abstract void TakeDamage(int value);

    public void Attack(Animator animator, ColliderFinder colliderFinder, int maxDamage)
    {
        if (colliderFinder.TryGetCollider(out Collider2D collider))
        {
            if (collider.TryGetComponent(out Fighter fighter))
            {
                if (fighter.isActiveAndEnabled)
                {
                    fighter.TakeDamage(Random.Range(0, maxDamage));
                }
            }
        }

        animator.SetTrigger(AnimatorConstants.Attack.ToString());
    }
}