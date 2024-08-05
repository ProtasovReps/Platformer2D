using System;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    public event Action<bool> FighterSeen;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Fighter>(out _))
            FighterSeen?.Invoke(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Fighter>(out _))
            FighterSeen?.Invoke(false);
    }
}