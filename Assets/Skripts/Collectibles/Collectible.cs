using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class Collectible : MonoBehaviour
{
    private Coroutine _coroutine;

    public virtual void Appear(Vector2 position)
    {
        transform.position = position;
        gameObject.SetActive(true);
    }

    protected abstract void OnTriggerEnter2D(Collider2D collision);

    protected abstract void ApplyEffect(Collector collector);

    protected void Follow(Collector collector)
    {
        if (gameObject.activeSelf && _coroutine == null)
            _coroutine = StartCoroutine(FollowSmoothly(collector));
    }

    private IEnumerator FollowSmoothly(Collector collector)
    {
        float pickUpSpeed = 15;
        Vector3 targetPosition = collector.transform.position;

        while (transform.position != targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * pickUpSpeed);
            pickUpSpeed++;

            yield return null;
        }

        Disappear();

        _coroutine = null;
    }

    private void Disappear() => gameObject.SetActive(false);
}