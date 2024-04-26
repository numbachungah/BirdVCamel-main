using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerInteraction : MonoBehaviour
{
    public int health = 10000;
    public Slider slider;
    private Animator anim;
    private void Start()
   
    {
        anim = GetComponent<Animator>();
        slider.maxValue = health;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collided object is an enemy
        if (other.CompareTag("Enemy") && other.isTrigger == false)
        {
            DamageTower();
            Destroy(other.gameObject);


        }
    }

    void DamageTower()
    {
        slider.value = health;
        health -= 500;
        Debug.Log("Tower health: " + health);

        // Check if tower health is zero
        if (health <= 0)
        {
            health = 0;

            anim.SetTrigger("Death");
            

            Debug.Log("Tower destroyed!");
            // Implement game over logic here


        }
    }
}

