using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public int requiredKeyLevel = 1;

    [Header("Door Parts")]
    public Animator hingeAnimator; // Assign in the inspector

    private bool isOpen = false;

    public void Interact(GrabSystem grabSystem)
    {
        if (isOpen) return;

        bool canOpen = false;

        foreach (KeyCardData keyCard in InventoryManager.Instance.keyCardInventory.Values)
        {
            if (keyCard.keyLevel >= requiredKeyLevel)
            {
                canOpen = true;
                break;
            }
        }

        if (canOpen)
        {
            Debug.Log("Door opening: Access granted.");
            if (hingeAnimator != null)
            {
                hingeAnimator.Play("DoorOpen");
                isOpen = true;
            }
        }
        else
        {
            Debug.Log("Access denied: Requires keycard level " + requiredKeyLevel);
        }
    }
}
