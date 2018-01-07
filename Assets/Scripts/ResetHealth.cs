using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompleteProject
{
    public class ResetHealth : MonoBehaviour
    {
        public float TimerbetwwtimeBetweenHealth = 0.5f;

        public PlayerHealth playerHealth;
        public GameObject player;
        bool playerInRange;
        float timer;
        void Start()
        {

        }
        void Update()
        {
            timer += Time.deltaTime;
            if (playerHealth.currentHealth > 0 && playerHealth.currentHealth < 100 && playerInRange && timer >= TimerbetwwtimeBetweenHealth)
            {
                playerHealth.currentHealth += 5;
                timer = 0;
            }
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject == player)
            {
                playerInRange = true;
            }
        }


        void OnTriggerExit(Collider other)
        {
            if (other.gameObject == player)
            {
                playerInRange = false;
            }
        }
    }
}
