using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompleteProject
{
    public class AmmoMeneger : MonoBehaviour
    {

        public GameObject AmmoBox;
        GameObject player;
        float timer;
        public float TimeLifeAmmo=5f;
        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            timer = 0;
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject == player)
            {
                PlayerShooting.CurrentAmmo += 10;
                DestroyObj();
            }
        }

        void Update()
        {
            timer += Time.deltaTime;
            if (timer >= TimeLifeAmmo)
            {
                DestroyObj();
            }
        }

        void DestroyObj()
        {
            Destroy(AmmoBox, 0.1f);
        }
    }
}
