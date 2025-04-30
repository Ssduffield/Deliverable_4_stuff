using UnityEngine;

public interface IGrabbable : IInteractable
{
    // Called when the item is picked up.
    void Pickup(GrabSystem grabSystem);
    // Adjust visual transparency.
    void SetTransparency(float alpha);
    // Return the associated item data.
    ItemData GetItemData();
    void Drop(GrabSystem grabSystem);
}
