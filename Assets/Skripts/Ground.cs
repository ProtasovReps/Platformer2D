using UnityEngine;

public class Ground : MonoBehaviour
{
    public Vector2 GetRandomPosition(float upPosition)
    {
        float positionY = transform.position.y + upPosition;
        float startPointX = transform.position.x - (transform.lossyScale.x / 2);
        float endPointX = transform.position.x + (transform.lossyScale.x / 2);

        return new Vector2(Random.Range(startPointX, endPointX), positionY);
    }
}
