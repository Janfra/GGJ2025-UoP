using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class WaypointManager : MonoBehaviour
{
    [SerializeField]
    private Waypoint[] waypoints = null;

    public Waypoint GetRandomStart(out WaypointData data)
    {
        if (waypoints == null || waypoints.Length == 0)
        {
            data = new WaypointData();
            return null;
        }

        int waypointIndex = Random.Range(0, Mathf.Max(waypoints.Length, 0));
        Waypoint selectedWaypoint = waypoints[waypointIndex];
        data = new WaypointData(selectedWaypoint, waypointIndex); 
        return selectedWaypoint;
    }

    public WaypointData GetNextPosition(WaypointData data)
    {
        Waypoint waypoint = waypoints[data.WaypointIndex];
        data.DistanceTravelled += (data.Speed * Time.deltaTime) / data.PathDistance;
        data.TargetPosition = waypoint.pathsContainer.EvaluatePosition(data.DistanceTravelled);
        return data;
    }
}

public struct WaypointData
{
    private int waypointIndex;
    private int pathIndex;
    private float pathDistance;

    public int WaypointIndex => waypointIndex;
    public int PathIndex => pathIndex;
    public float PathDistance => pathDistance;

    public float Speed;
    public float DistanceTravelled;
    public Vector3 TargetPosition;

    public WaypointData(Waypoint waypoint, int index)
    {
        pathIndex = Random.Range(0, Mathf.Max(waypoint.pathsContainer.Splines.Count, 0));
        pathDistance = waypoint.pathsContainer.CalculateLength(pathIndex);
        waypointIndex = index;

        Speed = 0.0f;
        DistanceTravelled = 0.0f;
        TargetPosition = Vector2.zero;
    }
}