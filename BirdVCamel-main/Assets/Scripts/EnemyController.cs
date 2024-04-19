using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int maxHealth = 25; // Maximum health of the enemy
    private int currentHealth; // Current health of the enemy

    // Called when the enemy object is initialized
    private void Start()
    {
        currentHealth = maxHealth; // Set initial health to maxHealth
    }

    // Method to handle taking damage
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount; // Reduce current health by damage amount

        // Check if the enemy has been defeated
        if (currentHealth <= 0)
        {
            Die(); // Call the Die method if health is zero or less
        }
    }

    // Method to handle enemy death
    private void Die()
    {
        // Perform any death-related actions here (e.g., play death animation, spawn particles, etc.)
        Destroy(gameObject); // Destroy the enemy object
    }
}

