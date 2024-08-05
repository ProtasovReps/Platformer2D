public class KillCounter : Counter
{
    public KillCounter(EnemySpawner enemySpawner) : base()
    {
        enemySpawner.EnemyReleased += Increase;
    }
}
