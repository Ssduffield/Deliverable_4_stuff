using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public DamageData damageData;

    private void OnCollisionEnter(Collision collision)
    {
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
        if (damageable != null)
        {
            int damage = (damageData != null) ? damageData.damageAmount : 10;
            damageable.TakeDamage(damage);
        }
    }
}
