using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeLine : MonoBehaviour
{
    private RopeCreator rope;
    LineRenderer line;

    private void Awake()
    {
        rope = GetComponent<RopeCreator>();
        line = rope.GetComponent<LineRenderer>();
        line.enabled = true;
        line.positionCount = rope.segments.Length;
    }

    private void Update()
    {
        for (int i = 0; i < rope.segments.Length; i++)
        {
            line.SetPosition(i, rope.segments[i].position);
        }
    }
}
