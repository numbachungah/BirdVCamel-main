using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab;
    public float spawnRate = 8.0f;

    private float spawnTimer = 0.0f;

    void Update()
    {
        // Update spawn timer
        spawnTimer += Time.deltaTime;

        // Spawn enemies
        if (spawnTimer >= spawnRate)
        {
            SpawnEnemy();
            spawnTimer = 0.0f;

        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }
    
}

