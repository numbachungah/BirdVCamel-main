using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletController : MonoBehaviour
{
    public int damageAmount = 1; // Amount of damage the bullet deals

    // Called when the bullet collides with another object
    private void OnCollisionEnter2D(Collision2D other)
    {
        // Check if the collided object is an enemy
        EnemyController enemy = other.gameObject.GetComponent<EnemyController>();

        // If it's an enemy, apply damage and destroy the bullet
        if (enemy != null)
        {
            enemy.TakeDamage(damageAmount);
            
        }
        
         Destroy(gameObject);// Destroy the bullet upon collision
    }
}

