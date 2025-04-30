using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/Explosive Launcher")]
public class ExplosiveLauncher : WeaponBase, IWeapon, IExplosive
{
    public GameObject projectilePrefab;
    public float projectileSpeed = 20f;

    private int radius = 30;
    private int power = 200;

    public int damageAmount;

    public override void UseWeapon(Transform shootPoint)
    {
        GameObject projectile = GameObject.Instantiate(projectilePrefab,
            shootPoint.position, Quaternion.identity);

        projectile.GetComponent<Rigidbody>().velocity = shootPoint.forward * projectileSpeed;

        Debug.Log("Projectile was fired!");

        shootPoint.GetComponent<MonoBehaviour>().StartCoroutine(Explode(projectile, 3f, radius, power));
    }

    public IEnumerator Explode(GameObject projectile, float delay, int blastRadius, int blastPower)
    {
        Debug.Log("Start Timer");

        yield return new WaitForSeconds(delay);

        Debug.Log("Boom");
        Vector3 explosionPos = projectile.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(blastPower, explosionPos, blastRadius, 1.0F);

                if(hit.GetComponent<MonoBehaviour>() != null)
                {
                    hit.GetComponent<MonoBehaviour>().StartCoroutine(DamageOverTime(hit, 1f, 5));
                }
            }
        }
        Destroy(projectile);
    }

    private IEnumerator DamageOverTime(Collider hit, float delayBetweenDamage, int amountOfTimes)
    {
        for (int i = 0; i < amountOfTimes; i++)
        {
            yield return new WaitForSeconds(delayBetweenDamage);
            hit.GetComponent<IDamageable>()?.TakeDamage(damageAmount);
        }
    }
}
