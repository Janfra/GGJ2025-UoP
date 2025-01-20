using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollow : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private WaypointManager path;
    private WaypointData movementData;

    // Start is called before the first frame update
    void Start()
    {
        path.GetRandomStart(out movementData);
        movementData.Speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        movementData = path.GetNextPosition(movementData);
        transform.position = movementData.TargetPosition;
    }
}
