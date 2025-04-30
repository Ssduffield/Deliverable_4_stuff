using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IDamageable
{
    public int enemyHealth = 50;

    public void TakeDamage(int damage)
    {
        enemyHealth -= damage;
        Debug.Log("Enemy took " + damage + " damage");
        if (enemyHealth <= 0)
        {
            gameObject.SetActive(false);
            Debug.Log(transform.name + " died");
        }
    }
}
