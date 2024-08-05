using System;
using UnityEngine;

public class GroundPlatformStash : MonoBehaviour
{
    [SerializeField] private Ground[] _groundPlatforms;

    public Ground GetRandomPlatform()
    {
        int randomIndex = UnityEngine.Random.Range(0, _groundPlatforms.Length);
        Ground ground = _groundPlatforms[randomIndex];

        if (ground != null)
            return ground;
        else
            throw new ArgumentNullException(nameof(ground));
    }
}
