using UnityEngine;

public abstract class Fighter : MonoBehaviour
{
    public abstract void TakeDamage(int value);
    
    protected void Attack(Animator animator, ColliderFinder colliderFinder, int maxDamage)
    {
        animator.SetTrigger(AnimatorConstants.Attack.ToString());

        if (colliderFinder.TryGetCollider(out Collider2D collider))
        {
            if (collider.TryGetComponent(out Fighter fighter))
            {
                fighter.TakeDamage(Random.Range(0, maxDamage));
            }
        }
    }
}