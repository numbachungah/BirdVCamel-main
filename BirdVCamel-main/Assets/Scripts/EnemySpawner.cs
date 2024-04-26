using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab;
    public float spawnRate = 25.0f;

    private float spawnTimer = 0.0f;
    private int camelSpawned = 0;


    private void Start()
    {
        SpawnEnemy();
    }

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

        switch (camelSpawned)
        {
            case 0:
                spawnRate = 25;
                break;
            case 6:
                spawnRate = 18;
                break;
            case 10:
                spawnRate = 15;
                break;
            case 13: 
                spawnRate = 13;
                break;
            case 14:
                spawnRate = 10;
                break;
            case 20:
                spawnRate = 8;
                break;
            case 35:
                spawnRate = 7;
                break;
            case 38:
                spawnRate = 5;
                break;
            case 50: 
                spawnRate = 4;
                break;
            case 75:
                spawnRate = 3;
                break;
            case 90:
                spawnRate = 2;
                break;
            case 150:
                spawnRate = 1;
                break;
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        camelSpawned++;

    }
    
}

