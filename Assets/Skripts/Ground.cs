using UnityEngine;

public class Ground : MonoBehaviour
{
    public Vector2 Position => transform.position;

    public Vector2 Scale => transform.lossyScale;
}
