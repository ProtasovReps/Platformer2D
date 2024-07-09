using UnityEngine;

public abstract class Fighter : MonoBehaviour
{
    public abstract void TakeDamage(int value);
    
    protected abstract void Attack();

    protected int GetRandomDamage(int maxDamage) => Random.Range(0, maxDamage);
}