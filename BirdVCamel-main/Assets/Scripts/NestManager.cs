using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NestManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject nestPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(nestPrefab, spawnPoints[Random.Range(0, spawnPoints.Length)].position,Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
