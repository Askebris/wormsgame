using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class ActivePlayerWeapon : MonoBehaviour
{
    [SerializeField] private float weaponDamage;
    [SerializeField] private Transform weaponBarrel;
    [SerializeField] private LineRenderer lineRenderer;

    public void ShootLaser()
    {
        RaycastHit result;
        bool thereWasHit = Physics.Raycast(weaponBarrel.position, transform.forward, out result, Mathf.Infinity);

        lineRenderer.SetPosition(0, weaponBarrel.position);

        if (thereWasHit)
        {
            ActivePlayerHealth activePlayerHealth = result.collider.GetComponent<ActivePlayerHealth>();

            if(activePlayerHealth != null)
            {
                activePlayerHealth.TakeDamage(weaponDamage);
            }

            lineRenderer.SetPosition(1, result.point);

        }

        else
        {
            lineRenderer.SetPosition(1, weaponBarrel.position + transform.forward * 50);
        }
    }
}
