using System;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    public event Action<Fighter> FighterSeen;
    public event Action FighterLost;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Fighter fighter))
            FighterSeen?.Invoke(fighter);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Fighter fighter))
            FighterLost?.Invoke();
    }
}