using UnityEngine;

public class UserInterface : MonoBehaviour
{
    [SerializeField] private SmoothSliderStatView _healthView;
    [SerializeField] private TextStatView _walletView;
    [SerializeField] private TextStatView _killCountView;

    private KillCounter _killCounter;

    public void Initialize(Player player, EnemySpawner enemySpawner)
    {
        _killCounter = new KillCounter(enemySpawner);

        _healthView.Initialize(player.GetHealthAsStatShareable());
        _walletView.Initialize(player.GetWalletAsStatShareable());
        _killCountView.Initialize(_killCounter);
    }
}