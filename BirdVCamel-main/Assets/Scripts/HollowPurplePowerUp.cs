using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalacticBlasterPowerUp : MonoBehaviour
{
    public GameObject projectilePrefab; // The prefab of the giant projectile
    public float projectileSpeed = 2f; // Speed of the projectile
    public LayerMask enemyLayer; // Layer mask for enemies

    private bool hasBeenPickedUp = false; // Flag to track if the power-up has been picked up

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!hasBeenPickedUp)
            {
                // Apply power-up to the player
                ApplyPowerUp(other.gameObject);
                // Set the flag to prevent further picking up
                hasBeenPickedUp = true;
                // Destroy the power-up object
                Destroy(gameObject);
            }
        }
    }

    void ApplyPowerUp(GameObject player)
    {
        // Add the GalacticBlasterPlayer component to the player object
        GalacticBlasterPlayer galacticBlasterPlayer = player.GetComponent<GalacticBlasterPlayer>();
        if (galacticBlasterPlayer == null)
        {
            galacticBlasterPlayer = player.AddComponent<GalacticBlasterPlayer>();
        }
        // Set the parameters of the power-up
        galacticBlasterPlayer.projectilePrefab = projectilePrefab;
        galacticBlasterPlayer.projectileSpeed = projectileSpeed;
        galacticBlasterPlayer.enemyLayer = enemyLayer;
    }
}

public class GalacticBlasterPlayer : MonoBehaviour
{
    public GameObject projectilePrefab; // The prefab of the giant projectile
    public float projectileSpeed = 2f; // Speed of the projectile
    public LayerMask enemyLayer; // Layer mask for enemies

    private bool canShoot = true; // Flag to prevent rapid shooting

    void Update()
    {
        // Check if the space bar is pressed and the player can shoot
        if (Input.GetKeyDown(KeyCode.Space) && canShoot)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Instantiate the projectile
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        // Set the projectile's velocity to move slowly to the left
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.velocity = -transform.right * projectileSpeed; // Moving to the left

        // Prevent further shooting
        canShoot = false;

        // Destroy the projectile after 15 seconds
        Destroy(projectile, 6f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (enemyLayer == (enemyLayer | (1 << other.gameObject.layer)))
        {
            // Check if the collided object is an enemy
            Destroy(other.gameObject);
        }
    }
}
