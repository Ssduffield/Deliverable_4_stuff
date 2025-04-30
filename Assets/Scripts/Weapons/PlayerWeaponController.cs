using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    //Make better later
    public WeaponBase pistol;
    public WeaponBase tranq;
    public WeaponBase explosive;
    public GunController gun;

    [SerializeField] private Transform _shootPoint;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            gun.currentEquipWeapon = pistol;
            Debug.Log("Pistol equipped");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            gun.currentEquipWeapon = tranq;
            Debug.Log("Tranq gun equipped");
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            gun.currentEquipWeapon = explosive;
            Debug.Log("Explosive launcher equipped");
        }

        if (Input.GetMouseButtonDown(0))
        {
            gun.UseWeapon(_shootPoint);
        }
    }
}
