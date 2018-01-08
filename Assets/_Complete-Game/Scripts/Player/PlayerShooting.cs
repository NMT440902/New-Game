using UnityEngine;


namespace CompleteProject
{
    public class PlayerShooting : MonoBehaviour
    {
        public int damagePerShot = 20;                  
        public float timeBetweenBullets = 0.15f;        
        public float range = 100f;

        public int startingAmmo = 100;
        public static int CurrentAmmo;
        float timer;                                    
        Ray shootRay;                                   
        RaycastHit shootHit;                           
        int shootableMask;                              
        ParticleSystem gunParticles;                    
        LineRenderer gunLine;                           
        AudioSource gunAudio;                          
        Light gunLight;                                 
        float effectsDisplayTime = 0.2f;
        bool EnemyInRange;
        int TypeAtake = 0;
        EnemyHealth enamy;
        Collider shColider;
        GameObject player;

        void Awake()
        {
            shootableMask = LayerMask.GetMask("Shootable");

            CurrentAmmo = startingAmmo;
            player = GameObject.FindGameObjectWithTag("Player");
            gunParticles = GetComponent<ParticleSystem>();
            gunLine = GetComponent<LineRenderer>();
            gunAudio = GetComponent<AudioSource>();
            gunLight = GetComponent<Light>();
            shColider = GetComponent<Collider>();

        }

        void Update()
        {
            ScoreManager.ammunition=CurrentAmmo;

            timer += Time.deltaTime;

            if (Input.GetButton("Fire1") && timer >= timeBetweenBullets && TypeAtake == 1 && CurrentAmmo > 0)
            {
                Shoot();
                CurrentAmmo -= 1;

            }
            if (Input.GetButton("Fire1") && timer >= timeBetweenBullets && TypeAtake == 2)
            {
                beat();
            }

            if (timer >= timeBetweenBullets * effectsDisplayTime)
            {
                DisableEffects();
            }
        }

        public void DisableEffects()
        {
            gunLine.enabled = false;
            gunLight.enabled = false;
        }

        void Shoot()
        {
            timer = 0f;

            gunAudio.Play();

            gunLight.enabled = true;

            gunParticles.Stop();
            gunParticles.Play();

            gunLine.enabled = true;
            gunLine.SetPosition(0, transform.position);

            shootRay.origin = transform.position;
            shootRay.direction = transform.forward;

            if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
            {
                EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();

                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(damagePerShot, shootHit.point);
                }

                gunLine.SetPosition(1, shootHit.point);
            }
            else
            {
                gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
            }
        }

        void beat()
        {
            timer = 0f;
            Collider[] enemys = Physics.OverlapSphere(player.transform.position, 3,shootableMask);

            for (int i = 0; i < enemys.Length; i++)
            {
                EnemyHealth enemyHealth = enemys[i].GetComponent<EnemyHealth>();        

                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(200, enemyHealth.transform.position);
                }
            }
            
        }

        public void changeTypeAtacke(int newTypeAtacke)
        {
            TypeAtake = newTypeAtacke;
        }
  
    }
}