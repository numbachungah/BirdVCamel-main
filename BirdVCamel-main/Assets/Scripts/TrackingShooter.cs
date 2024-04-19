using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform target;
    public float bulletSpeed = 5f;
    public float accelerationRate = 0.1f; // Rate of acceleration for the tracking bullet
    public int bulletDamage = 20; // Damage per bullet

    private GameObject currentBullet;
    private void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (currentBullet == null)
            {
                Shoot();
            }
            else
            {
                TrackTarget();
            }
        }
    }
   

    void Shoot()
    {
        currentBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        BulletController bulletController = currentBullet.GetComponent<BulletController>();
        bulletController.SetDamage(bulletDamage);
        Vector2 direction = (target.position - transform.position).normalized;
        currentBullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }

    void TrackTarget()
    {
        if (currentBullet != null)
        {
            Vector2 direction = (target.position - currentBullet.transform.position).normalized;
            currentBullet.GetComponent<Rigidbody2D>().velocity += direction * accelerationRate * Time.deltaTime;
        }
    }
}


