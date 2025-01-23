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
    }
}
