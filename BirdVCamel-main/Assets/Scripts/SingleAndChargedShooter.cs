using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleAndChargedShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform target;
    public float bulletSpeed = 10f;
    public float shootInterval = 1.5f;
    public float chargeProbability = 0.1f; // Probability of charging shot (10%)
    public int bulletDamage = 1; // Damage per bullet
    public int chargedBulletDamage = 3; // Damage for charged shot

    private float shootTimer = 0f;
    private Animator anim;

    private void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

   void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            shootTimer += Time.deltaTime;

            if (shootTimer >= shootInterval)
            {
                Shoot();
                shootTimer = 0f;

                // Randomly decide to charge a shot
                if (Random.value < chargeProbability)
                {
                    ChargeShot();
                }

            }
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        BulletController bulletController = bullet.GetComponent<BulletController>();
        bulletController.SetDamage(bulletDamage);
        Vector2 direction = (target.position - transform.position).normalized;
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }

    IEnumerator ChargeShot()
    {
        // Implement charging behavior here
        Debug.Log("Charging shot...");
        yield return new WaitForSeconds(6);
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        BulletController bulletController = bullet.GetComponent<BulletController>();
        bulletController.SetDamage(chargedBulletDamage);
        Vector2 direction = (target.position - transform.position).normalized;
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }
}

