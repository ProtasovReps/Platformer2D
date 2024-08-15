using System;
using UnityEngine;

public class ClosestEnemySearcher
{
    public Enemy GetClosestEnemy(Vector2 position, Enemy[] enemies)
    {
        int firstPosition = 0;
        int minLength = 1;
        Enemy closestEnemy = enemies[firstPosition];

        if (enemies == null)
            throw new ArgumentNullException(nameof(enemies));

        if (enemies.Length <= minLength)
            return closestEnemy;

        foreach (Enemy enemy in enemies)
        {
            if (GetSquareDistance(position, enemy) < GetSquareDistance(position, closestEnemy))
            {
                closestEnemy = enemy;
            }
        }

        return closestEnemy;
    }

    private float GetSquareDistance(Vector2 position, Enemy enemy)
    {
        Vector2 offset = position - (Vector2)enemy.transform.position;

        return offset.sqrMagnitude;
    }
}
