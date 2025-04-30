using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GunUIManager : MonoBehaviour
{
    public TMP_Text gunNameText;
    public TMP_Text ammoText;
    public Image gunIconImage;

    // Call this method once when the gun is picked up.
    public void UpdateGunUI(GunData gunData)
    {
        
        gunNameText.gameObject.SetActive(true);
        ammoText.gameObject.SetActive(true);
        gunIconImage.gameObject.SetActive(true);
        
        if (gunData == null)
            return;
            
        gunNameText.text = gunData.gunName.ToString();
        ammoText.text = $"{gunData.bulletsInMag}/{gunData.magSize} - Total: {gunData.totalAmmo}".ToString();
        gunIconImage.sprite = gunData.itemIcon;
    }
    
    public void HideGunUI() {
        gunNameText.gameObject.SetActive(false);
        ammoText.gameObject.SetActive(false);
        gunIconImage.gameObject.SetActive(false);
    }

}
