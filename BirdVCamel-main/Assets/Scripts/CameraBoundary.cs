using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBoundary : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public SpriteRenderer[] boundarySprites; // Array of boundary sprites

    private Vector3 minBounds; // Minimum boundary position
    private Vector3 maxBounds; // Maximum boundary position
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        CalculateBoundary();
    }

    void Update()
    {
        if (player != null)
        {
            // Get the player's position
            Vector3 playerPos = player.position;

            // Clamp the camera position within the boundary
            float clampedX = Mathf.Clamp(playerPos.x, minBounds.x, maxBounds.x);
            float clampedY = Mathf.Clamp(playerPos.y, minBounds.y, maxBounds.y);

            // Update the camera position
            mainCamera.transform.position = new Vector3(clampedX, clampedY, mainCamera.transform.position.z);
        }
    }

    // Calculate the boundary based on the positions of the boundary sprites
    void CalculateBoundary()
    {
        if (boundarySprites.Length > 0)
        {
            minBounds = boundarySprites[0].bounds.min;
            maxBounds = boundarySprites[0].bounds.max;

            foreach (SpriteRenderer sprite in boundarySprites)
            {
                minBounds = Vector3.Min(minBounds, sprite.bounds.min);
                maxBounds = Vector3.Max(maxBounds, sprite.bounds.max);
            }
        }
        else
        {
            Debug.LogWarning("Boundary sprites are not assigned!");
        }
    }

    // Draw the boundary in the scene view for visualization purposes
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube((minBounds + maxBounds) / 2, maxBounds - minBounds);
    }
}
