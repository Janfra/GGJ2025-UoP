using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private TextMeshProUGUI text;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        int minutes = Mathf.FloorToInt(Time.time / 60f);
        text.text = $"{minutes}:{Mathf.FloorToInt(Time.time - minutes)}";
    }
}
