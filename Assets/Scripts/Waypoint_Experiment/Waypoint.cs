using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

[RequireComponent(typeof(SplineContainer))]
public class Waypoint : MonoBehaviour
{
    [SerializeField]
    public SplineContainer pathsContainer;

    public float GetPathLength(WaypointData data)
    {
        return pathsContainer.CalculateLength(data.PathIndex);
    }
}