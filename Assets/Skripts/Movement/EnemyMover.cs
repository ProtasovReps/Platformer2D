using System.Collections;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private LayerChecker _groundCheker;
    [SerializeField] private LayerChecker _playerCheker;
    [SerializeField] private EnemyVision _enemyVision;
    [SerializeField, Min(1)] private float _moveSpeed;

    private Coroutine _coroutine;
    private AnimatorToggler _animatorToggler;

    private void OnEnable()
    {
        _enemyVision.PlayerFound += StartChasing;
        _enemyVision.PlayerLost += StartPatrolling;

        StartPatrolling();
    }

    private void OnDisable()
    {
        _enemyVision.PlayerFound -= StartChasing;
        _enemyVision.PlayerLost -= StartPatrolling;
    }

    public void Initialize(AnimatorToggler animatorToggler)
    {
        _animatorToggler = animatorToggler;
        _animatorToggler.SetRunBool(true);
    }

    private void StartPatrolling()
    {
        StopMoving();

        if (gameObject.activeSelf)
            _coroutine = StartCoroutine(Patrol());
    }

    private void StartChasing()
    {
        StopMoving();

        if (gameObject.activeSelf)
            _coroutine = StartCoroutine(Chase());
    }

    private void StopMoving()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private IEnumerator Patrol()
    {
        while (enabled)
        {
            if (_groundCheker.CheckGround() == false)
                Rotate();

            if (_playerCheker.CheckEnemy())
                Rotate();

            transform.Translate(transform.right * _moveSpeed * Time.deltaTime, Space.World);
            yield return null;
        }
    }

    private IEnumerator Chase()
    {
        while (enabled)
        {
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
