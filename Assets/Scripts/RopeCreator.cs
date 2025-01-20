using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class RopeCreator : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public HingeJoint2D hingePrefab;

    [SerializeField, Range(2, 50)] private int segmentCount;

    [HideInInspector] public Transform[] segments;

    private Vector2 GetSegmentPosition(int segmentIndex)
    {
        float fraction = 1f / segmentCount;
        return Vector2.Lerp(pointA.position, pointB.position, fraction * segmentIndex);
    }

    [Button]
    private void GenerateRope()
    {
        segments = new Transform[segmentCount];
        for (int i = 0; i < segmentCount; i++)
        {
            HingeJoint2D currentJoint = Instantiate(hingePrefab, GetSegmentPosition(i), Quaternion.identity, transform);
            segments[i] = currentJoint.transform;
            if (i > 0)
            {
                currentJoint.connectedBody = segments[i - 1].GetComponent<Rigidbody2D>();
            }
        }
    }

    [Button]
    private void DeleteSegments()
    {
        if (transform.childCount > 0)
        {
            for (int i = transform.childCount - 1; i >= 0; i--)
            {
                DestroyImmediate(transform.GetChild(i).gameObject);
            }
        }

        segments = null;
    }

    private void OnDrawGizmos()
    {
        if (pointA == null || pointB == null)
        {
            return;
        }
        Gizmos.color = Color.green;
        for (int i = 0; i < segmentCount; i++)
        {
            Vector2 posAtIndex = GetSegmentPosition(i);
            Gizmos.DrawSphere(posAtIndex, 0.1f);
        }
    }
}
