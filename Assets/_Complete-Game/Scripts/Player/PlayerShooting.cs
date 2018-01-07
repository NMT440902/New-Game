using UnityEngine;


namespace CompleteProject
{
    public class PlayerShooting : MonoBehaviour
    {
        public int damagePerShot = 20;                  
        public float timeBetweenBullets = 0.15f;        
        public float range = 100f;                     

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

        void Awake()
        {
            shootableMask = LayerMask.GetMask("Shootable");

  
            gunParticles = GetComponent<ParticleSystem>();
            gunLine = GetComponent<LineRenderer>();
            gunAudio = GetComponent<AudioSource>();
            gunLight = GetComponent<Light>();

        }

        void Update()
        {
            //if (Input.GetKeyDown(KeyCode.Alpha1))
            //{
            //    TypeAtake = 1;
            //}

            //if (Input.GetKeyDown(KeyCode.Alpha2))
            //{
            //    TypeAtake = 2;
            //}

            timer += Time.deltaTime;

            if (Input.GetButton("Fire1") && timer >= timeBetweenBullets && TypeAtake==1)
            {
                Shoot();

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

            //gunAudio.Play();

            //gunLight.enabled = true;

            //gunParticles.Stop();
            //gunParticles.Play();

            gunLine.enabled = true;
            gunLine.SetPosition(0, transform.position);

            shootRay.origin = transform.position;
            shootRay.direction = transform.forward;

            if (Physics.Raycast(shootRay, out shootHit, 4, shootableMask))
            {
                EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();

                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(200, shootHit.point);
                }

                gunLine.SetPosition(1, shootHit.point);
            }
            else
            {
                gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
            }
        }

        public void changeTypeAtacke(int newTypeAtacke)
        {
            TypeAtake = newTypeAtacke;
        }
  
    }
}