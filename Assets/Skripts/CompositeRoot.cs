using UnityEngine;

public class CompositeRoot : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private CollectibleSpawner _collectibleSpawner;

    private void Awake()
    {
        _player.Initialize();
        _collectibleSpawner.Initialize();
    }
}
