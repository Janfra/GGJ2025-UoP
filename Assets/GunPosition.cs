using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPosition : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.SetPositionAndRotation(transform.parent.position + ((Vector3)InputShooting.shooterData.AimPosition - transform.parent.position).normalized, Quaternion.LookRotation(Vector3.forward, Vector3.Cross(transform.parent.position - transform.position, Vector3.forward)));
        transform.GetChild(0).localScale = new(WaterGun.currentRange / 3f, WaterGun.currentRange / 3f, 1);
    }
}
