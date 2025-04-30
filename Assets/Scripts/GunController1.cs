using UnityEngine;

public class GunController : MonoBehaviour //this whole demo script can be scrapped for an actual gun controller
{
    public WeaponBase currentEquipWeapon;

    public void UseWeapon(Transform shootPoint)
    {
        currentEquipWeapon?.UseWeapon(shootPoint);
    }

    /*
    public GunData gunData;
    public GunUIManager gunUIManager;
    
    private GunItem gunItem;

    private void Awake()
    {
        gunItem = GetComponent<GunItem>();
        if (gunItem == null)
        {
            Debug.LogError("GunItem component is missing on " + gameObject.name);
        }
    }

    private void Update()
    {
        // Only process input if the gun is equipped.
        if (gunItem == null || !gunItem.isEquipped)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    void Fire()
    {
        // Check if there are bullets left in the magazine.
        if (gunData.bulletsInMag > 0)
        {
            gunData.bulletsInMag--;
            Debug.Log("Fired! Bullets left in mag: " + gunData.bulletsInMag);

            // Update the UI with the new ammo values.
            if (gunUIManager != null)
            {
                gunUIManager.UpdateGunUI(gunData);
            }
        }
        else
        {
            Debug.Log("Magazine is empty. Press R to reload.");
        }
    }

    void Reload()
    {
        // Calculate how many bullets are needed to fill the magazine.
        int bulletsNeeded = gunData.magSize - gunData.bulletsInMag;
        if (bulletsNeeded > 0 && gunData.totalAmmo > 0)
        {
            // Reload as many bullets as possible.
            int ammoToReload = Mathf.Min(bulletsNeeded, gunData.totalAmmo);
            gunData.bulletsInMag += ammoToReload;
            gunData.totalAmmo -= ammoToReload;
            Debug.Log("Reloaded! Bullets in mag: " + gunData.bulletsInMag + " | Total ammo left: " + gunData.totalAmmo);

            // Update the UI after reloading.
            if (gunUIManager != null)
            {
                gunUIManager.UpdateGunUI(gunData);
            }
        }
        else
        {
            Debug.Log("Cannot reload: magazine is full or no ammo in reserve.");
        }
    }
    */
}
