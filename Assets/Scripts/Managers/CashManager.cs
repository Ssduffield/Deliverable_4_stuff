using UnityEngine;
using TMPro;

public class CashManager : MonoBehaviour
{
    public static CashManager instance;
    public int currentCash = 0;
    public TMP_Text cashText;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void AddCash(int amount)
    {
        currentCash += amount;
        UpdateCashUI();
    }
    private void UpdateCashUI()
    {
        if (cashText != null)
            cashText.text = "Cash: $" + currentCash.ToString();
    }
}
