using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtTrail : MonoBehaviour
{
    public GameObject dirt;

    private Vector3 lastPosition;

    private void Start()
    {
        lastPosition = transform.position;
    }

    private void Update()
    {
        if ((lastPosition - transform.position).sqrMagnitude > 0.2f)
        {
            Instantiate(dirt, transform.position, Quaternion.Euler(0f, 0f, Random.value * 360f));
            lastPosition = transform.position;
        }
    }
}
