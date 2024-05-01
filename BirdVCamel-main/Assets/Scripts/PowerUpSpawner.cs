using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject[] powerUps;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnPowerUp", 5, 5);
    }

    // Update is called once per frame
    void SpawnPowerUp()
    {
        Instantiate(powerUps[Random.Range(0,powerUps.Length)], transform.position,Quaternion.identity);
    }
}
