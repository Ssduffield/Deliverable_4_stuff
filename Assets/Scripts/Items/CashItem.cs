using UnityEngine;

public class CashItem : MonoBehaviour, IInteractable
{
    public CashItemData cashItemData;


    public void Interact(GrabSystem grabSystem)
    {
        if (cashItemData != null && cashItemData.cashValue > 0)
        {
            CashManager.instance.AddCash(cashItemData.cashValue);
            Destroy(gameObject);
        }
    }
}
