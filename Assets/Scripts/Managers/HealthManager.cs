using UnityEngine;
using TMPro;

public class HealthManager : MonoBehaviour, IDamageable
{
    public HealthData healthData;
    public TMP_Text healthText;

    private int currentHealth;

    private void Awake()
    {
        if (healthData == null)
        {
            Debug.LogError("HealthData is not assigned on " + gameObject.name);
            currentHealth = 100;
        }
        else
        {
            currentHealth = healthData.maxHealth;
        }
        UpdateHealthUI();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    
    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, healthData.maxHealth);
        UpdateHealthUI();
    }


    private void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth;
        }
    }

    private void Die()
    {
        Debug.Log(gameObject.name + " died.");
        Destroy(gameObject);
    }
}
