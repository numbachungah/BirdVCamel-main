using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private int damage = 1;

    public void SetDamage(int value)
    {
        damage = value;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if bullet collides with a target
        if (other.CompareTag("Player")) // Change "Player" to your target tag
        {
            // Deal damage to the target
            other.GetComponent<PlayerHealth>().TakeDamage(damage);

            // Destroy the bullet
            Destroy(gameObject);
        }
    }
}
