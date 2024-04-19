using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3.0f;

    void Update()
    {
        // Move enemy towards the right
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}

