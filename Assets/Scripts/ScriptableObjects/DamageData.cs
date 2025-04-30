using UnityEngine;

[CreateAssetMenu(fileName = "DamageData", menuName = "ScriptableObjects/DamageData")]
public class DamageData : ScriptableObject
{
    // Set the damage amount for an attack or damaging effect.
    public int damageAmount = 10;
}
