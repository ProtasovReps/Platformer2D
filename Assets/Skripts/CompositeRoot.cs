using UnityEngine;

public class CompositeRoot : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private UserInterface _userInterface;
    [SerializeField] private CollectibleSpawner _collectibleSpawner;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private Warehouse _collectibleStash;
    [SerializeField] private GroundPlatformStash _groundPlatformStash;

    private void Awake()
    {
        _player.Initialize();
        _enemySpawner.Initialize(_groundPlatformStash);
        _collectibleSpawner.Initialize(_groundPlatformStash, _collectibleStash);
        _userInterface.Initialize(_player);
    }
}
