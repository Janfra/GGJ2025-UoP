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
        rt.sizeDelta = new(stat switch { Stat.Soap => Player.soap * 130f, Stat.Dirtiness => Player.dirtiness * 130f, Stat.TownDirtiness => TownDirtiness.Instance.Dirtiness * 270f / 100f, _ => throw new System.NotImplementedException() }, 13f);
    }

    private enum Stat
    {
        Soap,
        Dirtiness,
        TownDirtiness
    }
}
