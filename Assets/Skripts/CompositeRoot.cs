using UnityEngine;

public class CompositeRoot : MonoBehaviour
{
    [SerializeField] private Character _player;
    [SerializeField] private UserInterface _userInterface;
    [SerializeField] private GroundPlatformStash _groundPlatformStash;
    [SerializeField] private CollectibleSpawner _collectibleSpawner;

    private void Awake()
    {
        _player.Initialize();
        _groundPlatformStash.Initialize();
        _collectibleSpawner.Initialize(_groundPlatformStash);
        _userInterface.Initialize();
    }
}
