using System.Collections.Generic;
using UnityEngine;

public class GroundPlatformStash : MonoBehaviour
{
    private List<Ground> _groundPlatforms;

    public void Initialize()
    {
        _groundPlatforms = new List<Ground>();
        _groundPlatforms.AddRange(gameObject.GetComponentsInChildren<Ground>()); 
    }

    public List<Ground> GetPlatforms()
    {
        var groundPlatforms = new List<Ground>();

        foreach (var ground in _groundPlatforms)
            groundPlatforms.Add(ground);

        return groundPlatforms;
    }
}
