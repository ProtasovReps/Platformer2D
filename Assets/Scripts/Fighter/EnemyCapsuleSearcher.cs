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
        bool isFound = false;

        foreach (Collider2D hit in hits)
        {
            if (hit.TryGetComponent(out Enemy enemy))
                enemyList.Add(enemy);
        }

        if (enemyList.Count > 0)
        {
            isFound = true;
            enemies = enemyList.ToArray();
        }
        else
        {
            enemies = null;
        }

        Found?.Invoke(isFound);
        return isFound;
    }
}