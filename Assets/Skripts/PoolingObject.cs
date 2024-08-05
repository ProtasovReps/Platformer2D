using System;
using UnityEngine;

public abstract class PoolingObject : MonoBehaviour
{
    public abstract event Action<PoolingObject> ReadyToRelease;
    
    public virtual void Release() => gameObject.SetActive(false);

    public virtual void Appear() => gameObject.SetActive(true);

    public void ChangePosition(Vector2 position) => transform.position = position;
}
