using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/Tranquilizer Gun")]
public class TranqGun : WeaponBase, IWeapon, INonLethal
{
    RaycastHit hit;

    public override void UseWeapon(Transform shootPoint)
    {
        if (Physics.Raycast(shootPoint.position, shootPoint.forward, out hit))
        {
            Debug.Log(" Tranq Hit " + hit.collider.name);
            shootPoint.GetComponent<MonoBehaviour>().StartCoroutine(PutToSleep(5f));
        }
    }

    public IEnumerator PutToSleep(float duration)
    {
        hit.transform.Rotate(0f, 0f, 90f);
        Debug.Log("Enemy sleeping...");

        yield return new WaitForSeconds(duration);

        hit.transform.Rotate(0f, 0f, -90f);
        Debug.Log("Enemy awake!");
    }
}
