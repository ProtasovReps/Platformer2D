using System;
using System.Collections.Generic;
using UnityEngine;

public class Warehouse : MonoBehaviour, IWarehouse
{
    [SerializeField] private List<IStashable> _stashables;

    public IStashable GetRandomStashable()
    {
        int randomIndex = UnityEngine.Random.Range(0, _stashables.Count);
        IStashable stashable = _stashables[randomIndex];

        if (stashable != null)
            return stashable;
        else
            throw new ArgumentNullException(nameof(stashable));
    }
}
