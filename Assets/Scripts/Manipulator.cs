using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompleteProject
{
    public class Manipulator : MonoBehaviour
    {
        public int typeAttake=1;
        GameObject player;
        PlayerShooting playerAttake;
        PlayerMovement playerMovement;
        bool playerInRange, status;
        void Start()
        {
            status = false;
            player = GameObject.FindGameObjectWithTag("Player");
            playerAttake = player.GetComponentInChildren <PlayerShooting>();
            playerMovement = player.GetComponent<PlayerMovement>();

        }

        void Update()
        {
            if (playerInRange && Input.GetKeyDown(KeyCode.E) && status==false)
            {
                playerMovement.ManipulatorTargetAttach(transform);
                playerAttake.changeTypeAtacke(typeAttake);
                status = true;
            }
            else if (status == true && Input.GetKeyDown(KeyCode.E))
            {
                playerMovement.ManipulatorTargetDetach(transform);
                playerAttake.changeTypeAtacke(0);
                status = false;
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
