using System;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    public event Action<bool> PlayerSeen;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out _))
            PlayerSeen?.Invoke(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out _))
            PlayerSeen?.Invoke(false);
    }
}