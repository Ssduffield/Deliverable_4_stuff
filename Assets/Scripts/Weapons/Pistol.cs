using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/Pistol")]
public class Pistol : WeaponBase, IWeapon
{
    public int damageAmount;

    public override void UseWeapon(Transform shootPoint)
    {
        RaycastHit hit;
        if (Physics.Raycast(shootPoint.position, shootPoint.forward, out hit))
        {
            Debug.Log("Lethal Hit " + hit.collider.name);

            hit.collider.GetComponent<IDamageable>()?.TakeDamage(damageAmount);
        }
    }
}
