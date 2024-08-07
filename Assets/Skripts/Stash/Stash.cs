using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Stash<T> : MonoBehaviour
{
    [SerializeField] private T[] _stashedItems;

    public T GetRandomItem()
    {
        int randomIndex = Random.Range(0, _stashedItems.Length);
        T randomItem = _stashedItems[randomIndex];

        if (randomItem != null)
            return randomItem;
        else
            throw new ArgumentNullException(nameof(randomItem));
    }
}
