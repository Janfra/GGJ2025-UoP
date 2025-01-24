using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dirt : MonoBehaviour
{
    [SerializeField]
    private TownDirtTracker townDirtTracker;
    [SerializeField]
    private float dirtiness;

    private void Start()
    {
        if (townDirtTracker == null)
        {
            throw new System.NullReferenceException($"The town dirt tracker has not been set in the Dirt component of {name}");
        }

        townDirtTracker.AddDirtiness(dirtiness);
    }

    private void Update()
    {
        townDirtTracker.AddDirtiness(dirtiness - TownDirtTracker.TownDirtiness);
    }

    private void OnDestroy()
    {
        townDirtTracker.RemoveDirtiness(dirtiness);
    }
}
