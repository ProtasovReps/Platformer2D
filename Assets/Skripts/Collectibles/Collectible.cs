using UnityEngine;

public abstract class Collectible : MonoBehaviour
{
    public virtual void Appear(Vector2 position)
    {
        transform.position = position;
        gameObject.SetActive(true);
    }

    public virtual void Disappear() => gameObject.SetActive(false);

    public abstract void OnTriggerEnter2D(Collider2D collision);
}
