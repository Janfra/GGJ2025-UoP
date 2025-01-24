using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreScreen : MonoBehaviour
{
    private TextMeshProUGUI text;
    [SerializeField]
    private PlayerScore score;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        text.text = "Score: " + score.Score;
    }
}
