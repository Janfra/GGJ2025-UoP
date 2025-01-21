using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtTrail : MonoBehaviour
{
    public GameObject dirtPrefab;

    private Vector3 lastPosition;
    private int index = 0;

    private void Start()
    {
        lastPosition = transform.position;
    }

    private void Update()
    {
        if ((lastPosition - transform.position).sqrMagnitude > 0.1f)
        {
            GameObject dirt = Instantiate(dirtPrefab, new(transform.position.x, transform.position.y), Quaternion.Euler(0f, 0f, Random.value * 360f));
            dirt.GetComponent<SpriteRenderer>().sortingOrder = index;
            index++;
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
