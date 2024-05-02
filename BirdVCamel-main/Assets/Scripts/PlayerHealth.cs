using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    private int currentHealth;
    public Animator anim;
    public Image healthBar;
    private bool isDead = false;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (!isDead)
        {
            currentHealth -= damage;
            UpdateHealthUI();

            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        isDead = true;
        // Handle player death
        Debug.Log("Player died!");

        // Disable player controls
        // Example: if player movement script is attached to the player object
        PlayerController playerMovement = GetComponent<PlayerController>();
        if (playerMovement != null)
        {
            playerMovement.enabled = false;
        }

        // Play death animation
        anim.SetTrigger("Death");

        // Invoke the method to load the game over scene after 4 seconds
        Invoke("LoadGameOverScene", 2.5f);
    }

    private void LoadGameOverScene()
    {
        SceneManager.LoadScene("Game Over");
    }

    public void IncreaseMaxHealth(int amount)
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = (float)currentHealth / maxHealth;
        }
    }
}

