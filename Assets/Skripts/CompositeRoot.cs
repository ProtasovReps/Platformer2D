using UnityEngine;

public class CompositeRoot : MonoBehaviour
{
    [SerializeField] private PlayerCharacter _player;
    [SerializeField] private UserInterface _userInterface;
    [SerializeField] private CollectibleSpawner _collectibleSpawner;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private GroundPlatformStash _groundPlatformStash;
    [SerializeField] private CollectibleStash _collectibleStash;

    private void Awake()
    {
        _player.Initialize();
        _enemySpawner.Initialize(_groundPlatformStash);
        _collectibleSpawner.Initialize(_groundPlatformStash, _collectibleStash);
        _userInterface.Initialize();
    }
}
