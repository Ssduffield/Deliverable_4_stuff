using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IExplosive
{
    IEnumerator Explode(GameObject projectile, float delay, int blastRadius, int blastPower);
}
