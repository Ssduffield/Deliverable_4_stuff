using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyCardUIManager : MonoBehaviour
{
    public static KeyCardUIManager Instance;

    public Image keyCardImage;
    public TMP_Text keyCardText;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    // Call this method to update the UI when a key card is collected.
    public void UpdateUI(KeyCardData keyCardData)
    {
        if (keyCardData != null)
        {
            keyCardImage.sprite = keyCardData.icon;
            keyCardText.text = keyCardData.cardName;

            // Ensure the UI elements are enabled.
            keyCardImage.gameObject.SetActive(true);
            keyCardText.gameObject.SetActive(true);
        }
    }
}
