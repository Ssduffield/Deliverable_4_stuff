using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : ScriptableObject, IWeapon
{
    public abstract void UseWeapon(Transform shootPoint);
}
