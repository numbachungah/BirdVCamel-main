using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float baseSpeed = 5f; // Base speed of the player
    public float bulletSpeed = 10f; // Speed of bullets fired
    public GameObject bulletPrefab; // Prefab of the bullet
    public Transform firePoint; // Point from where the bullets will be fired
    public float fireRate = 0.5f; // Fire rate in seconds
    private float nextFire = 0.0f; // Timer to control firing rate

    private Rigidbody2D rb;
    private Camera mainCamera;
    private SpriteRenderer mainSpriteRenderer;

    private float currentSpeed; // Current speed of the player
    private float speedBoostAmount; // Amount to increase speed by
    private float speedBoostDuration; // Duration of speed boost
    private float speedBoostTimer; // Timer for speed boost

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
        mainSpriteRenderer = GetComponent<SpriteRenderer>();
        currentSpeed = baseSpeed;
    }

    void Update()
    {
        // Player movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Debug.Log(moveHorizontal + " " + moveVertical);
        Vector2 movement = new Vector2(moveHorizontal, moveVertical).normalized;
        rb.velocity = movement * currentSpeed;

        // Shooting
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Shoot();
        }

        if (moveHorizontal > 0) { mainSpriteRenderer.flipX = true; }
        else { mainSpriteRenderer.flipX = false; }

        // Handle speed boost timer
        if (speedBoostTimer > 0)
        {
            speedBoostTimer -= Time.deltaTime;
            if (speedBoostTimer <= 0)
            {
                // Speed boost duration ended, reset speed
                currentSpeed = baseSpeed;
            }
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.velocity = firePoint.right * bulletSpeed;
    }

    void LateUpdate()
    {
        // Camera following
        if (mainCamera != null)
        {
            Vector3 targetPosition = transform.position;
            targetPosition.z = mainCamera.transform.position.z;
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, targetPosition, Time.deltaTime * 5f);
        }
    }

    public void ApplySpeedBoost(float amount, float duration)
    {
        speedBoostAmount = amount;
        speedBoostDuration = duration;
        speedBoostTimer = duration;

        // Increase speed
        currentSpeed += speedBoostAmount;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpeedPowerUp"))
        {
            // Apply speed boost when colliding with speed power-up
            SpeedPowerUp speedPowerUp = other.GetComponent<SpeedPowerUp>();
            if (speedPowerUp != null)
            {
                ApplySpeedBoost(speedPowerUp.speedIncreaseAmount, speedPowerUp.duration);
            }
            // Disable the power-up object
            other.gameObject.SetActive(false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawLine(transform.position, transform.forward * 5f);
    }
}
