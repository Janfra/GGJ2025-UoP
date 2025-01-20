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
        if ((lastPosition - transform.position).sqrMagnitude > 0.1f)
        {
            Instantiate(dirt, transform.position, Quaternion.Euler(0f, 0f, Random.value * 360f));
            lastPosition = transform.position;
        }

        Vector3 movement = new();

        if (Input.GetKey(KeyCode.RightArrow))
        {
            movement += Vector3.right;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            movement += Vector3.up;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            movement += Vector3.left;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            movement += Vector3.down;
        }

        transform.position += movement * Time.deltaTime * 2f;
    }
}
