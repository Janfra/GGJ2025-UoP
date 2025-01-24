using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoseSection : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        HingeJoint2D hinge = GetComponent<HingeJoint2D>();
        if (transform.GetSiblingIndex() != 0)
        {
            hinge.connectedBody = transform.parent.GetChild(transform.GetSiblingIndex() - 1).GetComponent<Rigidbody2D>();
        }

        if (transform.GetSiblingIndex() >= 5)
        {
            rb.MovePosition(Vector2.zero);
        }
    }

    private void Update()
    {
        if (transform.GetSiblingIndex() == 20 && Player.rb)
        {
            //Player.rb.mass = 99999f - (Mathf.Sqrt((transform.position - GameObject.Find("Fountain").transform.position).magnitude) * 57734.4495687f);
            Player.rb.mass = 99999f - ((transform.position - GameObject.Find("Fountain").transform.position).magnitude * 99999f);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Retract"))
        {
            rb.AddForce((-transform.position).normalized * 700f);
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
