using UnityEngine;

public class HealthPackItem : MonoBehaviour, IInteractable
{
    public HealthPackData healthPackData;

    public void Interact(GrabSystem grabSystem)
    {
        HealthManager healthManager = grabSystem.GetComponent<HealthManager>();
        if (healthManager != null)
        {
            healthManager.Heal(healthPackData.healAmount);
            Debug.Log($"{healthPackData.itemName} used. Healed for {healthPackData.healAmount} HP.");
        }

        // add UI effect and sound later on

        Destroy(gameObject);
    }
}
