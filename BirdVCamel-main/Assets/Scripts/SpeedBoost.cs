using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    public float speedIncreaseAmount = 5f; // Speed increase amount
    public float duration = 45f; // Duration of the power-up in seconds

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Apply speed increase to the player
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.ApplySpeedBoost(speedIncreaseAmount, duration);
            }
            // Disable the power-up object
            gameObject.SetActive(false);
        }
    }
}
