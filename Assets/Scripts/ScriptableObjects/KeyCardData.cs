using UnityEngine;

[CreateAssetMenu(fileName = "NewKeyCardData", menuName = "ScriptableObjects/KeyCardData")]
public class KeyCardData : ScriptableObject
{
    public int keyLevel;       // e.g. 1 or 2. A level 2 keycard will open both level 2 and level 1 doors.
    public string cardName;    // Display name of the keycard.
    public Sprite icon;        // Icon to show on the UI.
}
