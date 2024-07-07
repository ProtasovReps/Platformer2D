using System;
using System.Collections.Generic;
using UnityEngine;

public class GroundPlatformStash : MonoBehaviour
{
    [SerializeField] private List<Ground> _groundPlatforms;

    public Ground GetRandomPlatform()
    {
        int randomIndex = UnityEngine.Random.Range(0, _groundPlatforms.Count);
        Ground ground = _groundPlatforms[randomIndex];

        if (ground != null)
            return ground;
        else
            throw new ArgumentNullException();
    }
}
