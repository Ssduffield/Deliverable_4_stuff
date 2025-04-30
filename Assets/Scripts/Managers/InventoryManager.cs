using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    // Existing gun inventory.
    public Dictionary<string, GunItem> gunInventory = new Dictionary<string, GunItem>();

    // New key card inventory: key is the card's level.
    public Dictionary<int, KeyCardData> keyCardInventory = new Dictionary<int, KeyCardData>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void AddGun(string key, GunItem gun)
    {
        if (!gunInventory.ContainsKey(key))
        {
            gunInventory.Add(key, gun);
            Debug.Log("Gun added to inventory: " + key);
        }
        else
        {
            Debug.Log("Gun already exists in inventory: " + key);
        }
    }

    public void AddKeyCard(KeyCardData keyCardData)
    {
        if (!keyCardInventory.ContainsKey(keyCardData.keyLevel))
        {
            keyCardInventory.Add(keyCardData.keyLevel, keyCardData);
            Debug.Log("Key card added to inventory: " + keyCardData.cardName);
        }
        else
        {
            Debug.Log("Inventory already contains a key card of level " + keyCardData.keyLevel);
        }
    }
}
