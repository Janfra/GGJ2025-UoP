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
            rb.AddForce((GameObject.Find("Fountain").transform.position - transform.position).normalized * 500f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Hose Lock") && transform.GetSiblingIndex() == 20)
        {
            Hose.rb.mass = 1f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hose Lock") && transform.GetSiblingIndex() == 20)
        {
            Hose.rb.mass = 99999f;
        }
    }
}
