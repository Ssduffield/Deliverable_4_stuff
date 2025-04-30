using UnityEngine;

public class KeyCardItem : MonoBehaviour, IInteractable
{
    public KeyCardData keyCardData;

    // Called when the player presses F on this key card.
    public void Interact(GrabSystem grabSystem)
    {
        // Add the key card to the inventory.
        InventoryManager.Instance.AddKeyCard(keyCardData);

        // Update the UI so the player knows they have this key.
        KeyCardUIManager.Instance.UpdateUI(keyCardData);

        Debug.Log("Collected key card: " + keyCardData.cardName);

        // Remove the key card from the world.
        Destroy(gameObject);
    }
}
