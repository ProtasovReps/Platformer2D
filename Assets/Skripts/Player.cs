using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private Collector _collector;
    [SerializeField] private Animator _animator;
    
    private void Awake() => Initialize();

    private void Initialize()
    {
        _playerMover.Initialize(_animator);
        _collector.Initialize();
    }
}
