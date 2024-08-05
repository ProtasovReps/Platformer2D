using UnityEngine;

public class CompositeRoot : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private UserInterface _userInterface;
    [SerializeField] private Pool _collectibleSpawner;
    [SerializeField] private Pool _enemySpawner;

    private void Awake()
    {
        _player.Initialize();
        _enemySpawner.Initialize();
        _collectibleSpawner.Initialize();
        _userInterface.Initialize(_player);
    }
}
