using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoseSection : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Retract"))
        {
            rb.AddForce(Vector2.left * 500f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hose Lock") && transform.GetSiblingIndex() == 20)
        {
            transform.parent.GetChild(0).GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            Hose.speed = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Hose Lock") && transform.GetSiblingIndex() == 20)
        {
            transform.parent.GetChild(0).GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        }
    }
}
