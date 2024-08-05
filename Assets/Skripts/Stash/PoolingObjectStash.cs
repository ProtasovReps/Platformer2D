using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PoolingObjectStash : MonoBehaviour
{
    [SerializeField] private PoolingObject[] _poolingObjects;

    public PoolingObject GetRandomPoolingObject()
    {
        int randomIndex = Random.Range(0, _poolingObjects.Length);
        PoolingObject poolingObject = _poolingObjects[randomIndex];

        if (poolingObject != null)
            return poolingObject;
        else
            throw new ArgumentNullException(nameof(poolingObject));
    }
}
