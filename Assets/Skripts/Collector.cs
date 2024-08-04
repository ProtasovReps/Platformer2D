using UnityEngine;

[RequireComponent (typeof(Collider2D))]
public abstract class Collector : MonoBehaviour
{
    [SerializeField] private Transform _collectPoint;

    protected Vector3 CollectPoint => _collectPoint.position;

    protected abstract void OnTriggerEnter2D(Collider2D other);
}
