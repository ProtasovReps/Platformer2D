using UnityEngine;

public class ColliderFinder : MonoBehaviour
{
    [SerializeField] private LayerMask _layersToCheck;

    private float _distance = 0.5f;

    public bool TryGetCollider(out Collider2D collider)
    {
        collider = Physics2D.OverlapCircle(transform.position, _distance, _layersToCheck);
        return collider != null;
    }
}
