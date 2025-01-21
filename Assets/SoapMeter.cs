using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoapMeter : MonoBehaviour
{
    private RectTransform rt;

    private void Start()
    {
        rt = GetComponent<RectTransform>();
    }

    private void Update()
    {
        rt.sizeDelta = new(280f * Hose.soap, 30f);
    }
}
