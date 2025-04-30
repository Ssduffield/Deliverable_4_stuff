using UnityEngine;

[CreateAssetMenu(fileName = "NewGunData", menuName = "ScriptableObjects/GunData", order = 1)]
public class GunData : ScriptableObject
{
    public string gunName;
    public int magSize;
    public int bulletsInMag;
    public int totalAmmo;
    public Sprite itemIcon;
}
