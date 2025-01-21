using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShootable
{
    public void OnShot(ShootData data);
}

public struct ShootData
{
    public float damage;
}