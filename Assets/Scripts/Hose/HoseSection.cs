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

    private void Update()
    {
        if (transform.GetSiblingIndex() == 20 && Player.rb)
        {
            Player.rb.mass = 99999f - (Mathf.Sqrt((transform.position - GameObject.Find("Fountain").transform.position).magnitude) * 57734.4495687f);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Retract"))
        {
            rb.AddForce((GameObject.Find("Fountain").transform.position - transform.position).normalized * 500f);
        }
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Hose Lock") && transform.GetSiblingIndex() == 20)
    //    {
    //        if (Player.rb)
    //        {
    //            Player.rb.mass = 1f;
    //        }
    //    }
    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Hose Lock") && transform.GetSiblingIndex() == 20)
    //    {
    //        if (Player.rb)
    //        {
    //            Player.rb.mass = 99999f;
    //        }
    //    }
    //}
}
