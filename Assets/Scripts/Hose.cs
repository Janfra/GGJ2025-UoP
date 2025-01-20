using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hose : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * 100f;
        transform.up = rb.velocity;
    }
}
