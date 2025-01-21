using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Water Gun", menuName ="Weapons/Water Gun")]
public class WaterGun : BaseWeapon
{
    [SerializeField]
    private int range = 3;
    [SerializeField]
    private float maxRangeDelay = 1.0f;
    [SerializeField]
    private float minRadius;
    [SerializeField]
    private float maxRadius;

    private int circleCount;
    private float currentRange;
    private float duration;
    private float rangePercentage;
    private Coroutine growingRange;

    public override void StartShooting()
    {
        base.StartShooting();
        growingRange = shooterData.GameObject.StartCoroutine(GrowRange());
    }

    public override void Shoot()
    {
        circleCount = Mathf.CeilToInt(currentRange);
    }

    public override void StopShooting()
    {
        base.StopShooting();

        currentRange = 0.0f;
        if (growingRange != null)
        {
            shooterData.GameObject.StopCoroutine(growingRange);
        }
    }

    public IEnumerator GrowRange()
    {
        duration = 0.0f;
        currentRange = 0.0f;

        while (duration < maxRangeDelay && maxRangeDelay > 0.0f)
        {
            duration += Time.deltaTime;
            rangePercentage = Mathf.Min((duration + 1) / (maxRangeDelay + 1), 1.0f);
            currentRange = Mathf.Lerp(0, range, rangePercentage * rangePercentage);
            yield return null;
        }

        rangePercentage = 1.0f;
        currentRange = range;
        growingRange = null;
        yield return null;
    }

    public override void OnDrawGizmos()
    {
        if (shooterData == null)
        {
            return;
        }

        Gizmos.color = Color.green;

        Vector2 position = shooterData.Transform.position;
        position += shooterData.AimDirection * shooterData.ShooterCollider.bounds.extents.magnitude * 0.5f;

        for (int i = 0; i < circleCount; i++)
        {
            float value = (i + 1.0f) / range;
            float targetRadius = Mathf.Lerp(minRadius, maxRadius, value);
            float radius = Mathf.Lerp(0.0f, targetRadius, rangePercentage);
            position += shooterData.AimDirection * (radius * 2);
            Gizmos.DrawSphere(position, radius);
        }
    }
}
