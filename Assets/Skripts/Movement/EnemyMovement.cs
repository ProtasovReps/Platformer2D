using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private GroundChecker _groundCheker;
    [SerializeField] private EnemyVision _enemyVision;
    [SerializeField, Min(1)] private float _moveSpeed;

    private Coroutine _coroutine;
    private Animator _animator;

    private void OnEnable()
    {
        _enemyVision.FighterSeen += StartMoving;

        StartPatrolling();
    }

    private void OnDisable()
    {
        _enemyVision.FighterSeen -= StartMoving;
    }

    public void Initialize(Animator animator)
    {
        _animator = animator;
        _animator.SetBool(AnimatorConstants.IsRunning.ToString(), true);
    }

    private void StartMoving(bool isPlayerSeen)
    {
        if (isPlayerSeen)
            StartChasing();
        else
            StartPatrolling();
    }

    private void StartChasing()
    {
        StopMoving();

        if (gameObject.activeSelf)
            _coroutine = StartCoroutine(Chase());
    }

    private void StartPatrolling()
    {
        StopMoving();

        if (gameObject.activeSelf)
            _coroutine = StartCoroutine(Patrol());
    }

    private void StopMoving()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private IEnumerator Chase()
    {
        while (enabled)
        {
            transform.Translate(transform.right * _moveSpeed * Time.deltaTime, Space.World);
            yield return null;
        }
    }

    private IEnumerator Patrol()
    {
        while (enabled)
        {
            if (_groundCheker.CheckGround() == false)
                Rotate();

            transform.Translate(transform.right * _moveSpeed * Time.deltaTime, Space.World);
            yield return null;
        }
    }

    private void Rotate()
    {
        if (transform.rotation.y > 0)
            transform.rotation = Quaternion.Euler(Vector3.zero);
        else
            transform.rotation = Quaternion.Euler(new Vector3(0, 180));
    }
}
