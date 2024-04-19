using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slam : MonoBehaviour
{
    public float slamForce = 10f; // Adjust this to control the force of the slam
    public float slamAngle = -45f; // The angle of rotation during the slam
    public float slamDuration = 0.5f; // Duration of the slam animation
    public int slamDamage = 25; // Amount of damage to deal
    public float cooldown = 10f; // Cooldown time for the ability

    private bool isCooldown = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            // Check for nearby enemies and deal damage
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 2f);
            foreach (Collider2D collider in colliders)
            {
                if (collider.gameObject.CompareTag("Enemy"))
                {
                    EnemyController enemyHealth = collider.GetComponent<EnemyController>();
                    if (enemyHealth != null)
                    {
                        enemyHealth.TakeDamage(slamDamage);
                    }
                }
            }

            // Reset rotation
            transform.rotation = Quaternion.identity;

            // Start cooldown
            StartCoroutine(StartCooldown());
        }
    }

    private IEnumerator StartCooldown()
    {
        isCooldown = true;
        yield return new WaitForSeconds(cooldown);
        isCooldown = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isCooldown)
        {
            StartCoroutine(ExecuteSlam());
        }
    }

    IEnumerator ExecuteSlam()
    {
        // Rotate player
        transform.rotation = Quaternion.Euler(0, 0, slamAngle);

        // Apply downward force to the Rigidbody2D component
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * slamForce;

        // Wait for the duration of the slam
        yield return new WaitForSeconds(slamDuration);

        // Reset velocity to stop the downward movement
        rb.velocity = Vector2.zero;
    }
}





