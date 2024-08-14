using UnityEngine;

public class FighterRaycaster : MonoBehaviour
{
    [SerializeField] private LayerMask _layersToCheck;
    [SerializeField] private float _distance = 5f;

    public bool TryGetFighterByRaycast(out Fighter fighter)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, _distance, _layersToCheck);

        if (hit && hit.rigidbody.TryGetComponent(out Fighter foundFighter))
        {
            fighter = foundFighter;
            return true;
        }

        fighter = null;
        return false;
    }
}
