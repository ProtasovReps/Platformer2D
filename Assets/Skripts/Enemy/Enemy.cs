using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyMover _enemyMover;
    [SerializeField] private Animator _animator;

    private void Awake() => Initialize();

    private void Initialize()
    {
        _enemyMover.Initialize(_animator);
    }
}
