using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCapsuleSearcher : MonoBehaviour
{
    [SerializeField] private LayerMask _layersToCheck;
    [SerializeField] private Vector2 _capsuleSize;

    public event Action<bool> Found;

    public bool TryGetEnemyByCapsulecast(out Enemy[] enemies)
    {
        Collider2D[] hits = Physics2D.OverlapCapsuleAll(transform.position, _capsuleSize, CapsuleDirection2D.Horizontal, 0f, _layersToCheck);
        var enemyList = new List<Enemy>();

        foreach (Collider2D hit in hits)
        {
            if (hit.TryGetComponent(out Enemy enemy))
                enemyList.Add(enemy);
        }

        if (enemyList.Count > 0)
        {
            enemies = enemyList.ToArray();
            Found?.Invoke(true);
            return true;
        }
        else
        {
            enemies = null;
            Found?.Invoke(false);
            return false;
        }
    }
}