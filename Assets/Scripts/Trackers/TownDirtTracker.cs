using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Town Dirt Tracker", menuName = "Town Dirt Tracker")]
public class TownDirtTracker : ScriptableObject
{
    public delegate void DirtUpdate(float value);
    public event DirtUpdate maxDirtinessReached;
    public event DirtUpdate dirtinessAdded;
    public event DirtUpdate dirtinessRemoved;

    public float MaxDirtiness => maxDirtiness;
    [SerializeField]
    private float maxDirtiness;

    public float TownDirtiness => TownDirtiness;
    [NonSerialized]
    private float townDirtiness;

    public void AddDirtiness(float dirtiness)
    {
        townDirtiness += dirtiness;
        dirtinessAdded?.Invoke(townDirtiness);
        TryReachMaxDirtiness();
    }

    public void RemoveDirtiness(float dirtiness)
    {
        townDirtiness -= dirtiness;
        dirtinessRemoved?.Invoke(townDirtiness);
    }

    private void TryReachMaxDirtiness()
    {
        if (townDirtiness >= maxDirtiness)
        {
            maxDirtinessReached?.Invoke(townDirtiness);
        }
    }
}
