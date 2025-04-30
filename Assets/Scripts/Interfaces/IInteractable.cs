using UnityEngine;

public interface IInteractable
{
    // The GrabSystem is passed so the item can communicate context if needed.
    void Interact(GrabSystem grabSystem);
}
