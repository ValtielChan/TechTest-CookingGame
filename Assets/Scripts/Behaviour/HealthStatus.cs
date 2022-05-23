using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthStatus : MonoBehaviour
{
    /// <summary>
    /// The current amount of health
    /// </summary>
    [SerializeField]
    private int health;

    /// <summary>
    /// The maximum amount of health
    /// </summary>
    [SerializeField]
    private int maxHealth;

    /// <summary>
    /// Does the object disappear on dying
    /// </summary>
    [SerializeField]
    private bool destroyOnDie;

    /// <summary>
    /// The effect to instantiate when the object die
    /// </summary>
    [SerializeField]
    private GameObject dieEffectPrefab;

    /// <summary>
    /// Event fired when the object die
    /// </summary>
    public event UnityAction OnDie;

    /// <summary>
    /// Event fired when take damage
    /// </summary>
    public event UnityAction OnDamage;

    /// <summary>
    /// Get the current health amount
    /// </summary>
    public int Health { get => health; }

    /// <summary>
    /// Get the maximum health amount
    /// </summary>
    public int MaxHealth { get => maxHealth; }

    /// <summary>
    /// Increase the health amount
    /// </summary>
    /// <param name="amount">The amount of health added, the resulting health value can't be superior to MaxHealth</param>
    public void Heal(int amount)
    {
        health += amount;
        health = Mathf.Clamp(health, 0, maxHealth);
    }

    /// <summary>
    /// Decrease the health amount
    /// </summary>
    /// <param name="amount">The amount of health substracted, the resulting health value can't be inferior to zero</param>
    public void Damage(int amount)
    {
        health -= amount;
        health = Mathf.Clamp(health, 0, maxHealth);

        OnDamage?.Invoke();

        if (health <= 0)
        {
            Die();
        }
    }

    /// <summary>
    /// Kill the object and make it disappear
    /// </summary>
    public void Die()
    {
        // Instantiate effect if there's one
        if (dieEffectPrefab)
        {
            Instantiate(dieEffectPrefab, transform.position, transform.rotation);
        }

        OnDie?.Invoke();

        if (destroyOnDie)
        {
            Destroy(gameObject);
        }
    }
}
