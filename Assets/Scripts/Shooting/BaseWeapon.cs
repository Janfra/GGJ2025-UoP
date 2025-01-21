using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWeapon : ScriptableObject
{
    public bool IsShooting => isShooting;
    protected bool isShooting;
    protected ShooterData shooterData;

    public virtual void Initialise(ShooterData data) { shooterData = data; }

    public virtual void StartShooting() { isShooting = true; }
    public abstract void Shoot();
    public virtual void StopShooting() { isShooting = false; }

    public virtual void Terminate() { }

    public virtual void OnDrawGizmos() { }
}


public class ShooterData
{
    public MonoBehaviour GameObject;
    public Collider2D ShooterCollider;
    public Transform Transform;
    public Vector2 AimPosition;
    public Vector2 AimDirection => GetAimDirection();

    private Vector2 GetAimDirection()
    {
        if (Transform == null)
        {
            return new Vector2(0, 0);
        }

        Vector2 shooterPosition = Transform.position;
        Vector2 direction = AimPosition - shooterPosition;
        return direction.normalized;
    }
}