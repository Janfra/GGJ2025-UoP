using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtinessSpriteChange : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    private SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        sr.sprite = TownDirtTracker.TownDirtiness switch
        {
            < 25 => sprites[0],
            < 50 => sprites[1],
            < 75 => sprites[2],
            < 100 => sprites[3],
            _ => sprites[4],
        };
    }
}
