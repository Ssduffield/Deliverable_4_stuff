using UnityEngine;

[CreateAssetMenu(fileName = "NewHealthPackData", menuName = "ScriptableObjects/HealthPack")]
public class HealthPackData : ScriptableObject
{
    public int healAmount = 25;
    public string itemName = "Health Pack";
}
