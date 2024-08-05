using UnityEngine;

public class ColliderFinder : MonoBehaviour
{
    [SerializeField] private LayerMask _layersToCheck;
    [SerializeField] private float _radius = 5f;

    public bool TryGetCollider(out Collider2D collider)
    {
        collider = Physics2D.OverlapCircle(transform.position, _radius, _layersToCheck);
        return collider != null;
    }
}
