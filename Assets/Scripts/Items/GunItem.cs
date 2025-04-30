using UnityEngine;

public class GunItem : MonoBehaviour, IGrabbable
{
    public GunData gunData;
    public bool isEquipped = false;
    public GunUIManager gunUIManager;

    public void Interact(GrabSystem grabSystem)
    {
        Pickup(grabSystem);
        gunUIManager.UpdateGunUI(gunData);

    }

    public void Pickup(GrabSystem grabSystem)
{
    // Prevent picking up if an item is already held.
    if(grabSystem.HeldItem != null)
    {
         Debug.Log("Already holding an item. Cannot pick up another.");
         return;
    }
    
    // Add this gun to the inventory.
    InventoryManager invManager = InventoryManager.Instance;
    if (invManager != null)
    {
         invManager.AddGun(gameObject.name, this);
    }
    else
    {
         Debug.LogWarning("InventoryManager not found in the scene!");
    }
    
    // Register this gun as the held item.
    grabSystem.SetHeldItem(this);
    
    // Parent the gun to the gunPoint so that it follows the player's hold point.
    transform.SetParent(grabSystem.gunPoint);
    transform.localPosition = Vector3.zero;
    transform.localRotation = Quaternion.identity;
    
    // Disable physics so the gun stays put.
    Rigidbody rb = GetComponent<Rigidbody>();
    if (rb != null)
    {
         rb.isKinematic = true;
    }
    
    // Mark the gun as equipped.
    isEquipped = true;
    
    // Update the UI with the gun's data.
    if (gunUIManager != null)
    {
         gunUIManager.UpdateGunUI(gunData);
    }
    
    // Disable collisions with the player.
    Collider playerCol = grabSystem.GetComponent<Collider>();
    foreach (var gunCol in GetComponentsInChildren<Collider>())
    {
         if (playerCol != null)
              Physics.IgnoreCollision(gunCol, playerCol, true);
         // Optionally disable all collisions.
         gunCol.enabled = false;
    }
}

public void Drop(GrabSystem grabSystem)
{
    // Unset the equipped flag.
    isEquipped = false;
    
    // Unparent the gun so it is no longer attached to the player's hold point.
    transform.SetParent(null);
    
    // Re-enable physics.
    Rigidbody rb = GetComponent<Rigidbody>();
    if (rb != null)
    {
         rb.isKinematic = false;
    }
    
    // Re-enable colliders.
    Collider[] colliders = GetComponentsInChildren<Collider>();
    foreach (var col in colliders)
    {
         col.enabled = true;
    }
    
    // Hide the UI elements since the gun is dropped.
    if (gunUIManager != null)
    {
         gunUIManager.HideGunUI();
    }
    
    // (Optional) You can add additional logic here if you want the gun to be interactable again.
}


    public void SetTransparency(float alpha)
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            Material mat = renderer.material;
            Color newColor = mat.color;
            newColor.a = alpha;
            mat.color = newColor;
        }
    }

    public ItemData GetItemData()
    {
        return null;
    }
}
