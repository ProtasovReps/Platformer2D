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
        _enemyVision.FighterSeen += StartChasing;
        _enemyVision.FighterLost += StartPatrolling;

        StartPatrolling();
    }

    private void OnDisable()
    {
        _enemyVision.FighterSeen -= StartChasing;
        _enemyVision.FighterLost -= StartPatrolling;
    }

    public void Initialize(Animator animator)
    {
        _animator = animator;
    }

    private void StartChasing(Fighter fighter)
    {
        StopMoving();

        if (gameObject.activeSelf)
            _coroutine = StartCoroutine(Chase(fighter));
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

        _animator.SetBool(AnimatorData.Params.IsRunning, false);
    }

    private IEnumerator Chase(Fighter fighter)
    {
        _animator.SetBool(AnimatorData.Params.IsRunning, true);

        while (enabled)
        {
            float xOffset = fighter.transform.position.x - transform.position.x;
            Vector2 direction = new Vector2(xOffset, 0f).normalized;

            transform.Translate(direction * _moveSpeed * Time.deltaTime, Space.World);
            CheckDistance(fighter);
            yield return null;
        }
    }

    private IEnumerator Patrol()
    {
        _animator.SetBool(AnimatorData.Params.IsRunning, true);

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

    private void CheckDistance(Fighter fighter)
    {
        Vector2 offset = fighter.transform.position - transform.position;
        float squareDistance = Vector2.SqrMagnitude(offset);
        float maxDistance = 4f;

        if(squareDistance <= maxDistance)
            StopMoving();
    }
}
