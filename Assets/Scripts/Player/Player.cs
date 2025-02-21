using System.Collections;
using System.Collections.Generic;
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
        //rb.velocity = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * speed * (1f - dirtiness / 2f);
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
                dirtiness += 0.01f;
                TownDirtiness.Instance.Dirtiness -= 0.1f;
            }
            else
            {
                dirtiness += 0.05f;
            }
            dirtiness = Mathf.Clamp01(dirtiness);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Retract"))
        {
            soap += Time.fixedDeltaTime / 2f;
            dirtiness -= Time.fixedDeltaTime / 2f;
            soap = Mathf.Clamp01(soap);
            dirtiness = Mathf.Clamp01(dirtiness);
        }
    }
}
