using UnityEngine;

[RequireComponent (typeof(Collider2D))]
public abstract class Collector : MonoBehaviour
{
    protected abstract void OnTriggerEnter2D(Collider2D other);
}
