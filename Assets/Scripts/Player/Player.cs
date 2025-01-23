using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static float speed = 5;
    public static float soap = 1f;
    public static float dirtiness = 0f;
    public static Rigidbody2D rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //rb.velocity = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * speed * (1f - dirtiness / 2);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dirt"))
        {
            if (soap > 0)
            {
                Destroy(collision.gameObject);
                soap -= 0.01f;
                soap = Mathf.Clamp01(soap);
                dirtiness += 0.001f;
            }
            else
            {
                dirtiness += 0.01f;
            }
            dirtiness = Mathf.Clamp01(dirtiness);
        }
    }
}
