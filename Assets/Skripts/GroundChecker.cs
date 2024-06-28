using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private LayerMask _layerToCheck;
    
    public bool CheckGround() => Physics2D.Raycast(transform.position, Vector2.down, 0.5f, _layerToCheck);
}
