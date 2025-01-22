using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meter : MonoBehaviour
{
    [SerializeField] private Stat stat;
    private RectTransform rt;

    private void Start()
    {
        rt = GetComponent<RectTransform>();
    }

    private void Update()
    {
        rt.sizeDelta = new(280f * stat switch { Stat.Soap => Player.soap, Stat.Dirtiness => Player.dirtiness, _ => throw new System.NotImplementedException() }, 30f);
    }

    private enum Stat
    {
        Soap,
        Dirtiness
    }
}
