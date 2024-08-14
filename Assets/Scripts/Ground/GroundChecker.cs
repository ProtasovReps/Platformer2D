using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    private const string Ground = nameof(Ground);

    private float _distance = 0.5f;

    public bool CheckGround() => Physics2D.Raycast(transform.position, Vector2.down, _distance, LayerMask.GetMask(Ground));
}
