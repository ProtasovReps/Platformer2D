using System;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleStash : MonoBehaviour
{
    [SerializeField] private List<Collectible> _collectibles;

    public Collectible GetRandomCollectible()
    {
        int randomIndex = UnityEngine.Random.Range(0, _collectibles.Count);
        Collectible collectible = _collectibles[randomIndex];

        if (collectible != null)
            return collectible;
        else
            throw new ArgumentNullException();
    }
}
