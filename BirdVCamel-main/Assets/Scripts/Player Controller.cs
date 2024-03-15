using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // Player movement speed
    public float bulletSpeed = 10f; // Speed of bullets fired
    public GameObject bulletPrefab; // Prefab of the bullet
    public Transform firePoint; // Point from where the bullets will be fired
    public float fireRate = 0.5f; // Fire rate in seconds
    private float nextFire = 0.0f; // Timer to control firing rate

    private Rigidbody2D rb;
    private Camera mainCamera;
    private SpriteRenderer mainSpriteRenderer;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
        mainSpriteRenderer = GetComponent<SpriteRenderer>(); 
    }

    void Update()
    {
        // Player movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Debug.Log(moveHorizontal + " " + moveVertical);
        Vector2 movement = new Vector2(moveHorizontal, moveVertical).normalized;
        rb.velocity = movement * speed;

        // Shooting
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Shoot();
        }

        if (moveHorizontal > 0) { mainSpriteRenderer.flipX = true; }
        else {  mainSpriteRenderer.flipX = false; }
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
}



