using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PathFollow : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    public float speed;
    public WaypointManager path;
    private WaypointData movementData;

    // Start is called before the first frame update
    void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }

        speed += Random.Range(0.0f, 0.2f);
        transform.position = path.GetRandomStart(out movementData).transform.position;
        movementData.Speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        movementData = path.GetNextPosition(movementData);
        if (!movementData.HasArrived)
        {
            Vector2 direction = movementData.TargetPosition2D - position;
            rb.velocity = direction.normalized * movementData.Speed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }   
    }
}
    