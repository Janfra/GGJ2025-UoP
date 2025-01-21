using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputShooting : MonoBehaviour
{
    [SerializeField]
    private Transform aimAid;
    [SerializeField]
    private BaseWeapon weapon;
    private ShooterData shooterData = new ShooterData();

    private void Start()
    {
        if (weapon == null)
        {
            throw new System.NullReferenceException($"The player has no weapon set to use, unable to shoot");
        }

        shooterData.Transform = transform;
        shooterData.GameObject = this;
        shooterData.ShooterCollider = GetComponent<Collider2D>();

        weapon.Initialise(shooterData);
    }

    private void OnDestroy()
    {
        weapon.Terminate();
    }

    private void Update()
    {
        Camera cam = Camera.main;
        Vector3 mouseDelta = Input.mousePosition;
        mouseDelta.z = cam.nearClipPlane + 1;

        shooterData.AimPosition = cam.ScreenToWorldPoint(mouseDelta);
        aimAid.position = shooterData.AimPosition;

        if (Input.GetButton("Fire1"))
        {
            if (weapon == null)
            {
                throw new System.NullReferenceException($"The player has no weapon set to use, unable to shoot");
            }

            if (!weapon.IsShooting)
            {
                weapon.StartShooting();
            }

            weapon.Shoot();
        }
        else
        {
            if (weapon.IsShooting)
            {
                weapon.StopShooting();
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (weapon != null)
        {
            weapon.OnDrawGizmos();
        }
    }
}
