using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private Collector _collector;
    [SerializeField] private Animator _animator;
    
    public void Initialize()
    {
        _playerMover.Initialize(_animator);
        _collector.Initialize();
    }
}
