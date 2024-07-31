using System;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    public event Action PlayerFound;
    public event Action PlayerLost;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out _))
            PlayerFound?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out _))
            PlayerLost?.Invoke();
    }
}