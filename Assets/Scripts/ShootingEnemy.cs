using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : Enemies
{
    public float followDistance;
    public float retreatDistance;
    
    public float shootCooldown;
    public ProjectileContainer pc;

    private Player player;
    
    private Transform target;
    private float initCooldown = 0.0f;
    private GameObject projectile;
    private int nOfCorners;

    void Start()
    {
        sr= GetComponent<SpriteRenderer>();
        Initialization();
        InitShape();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        initCooldown = shootCooldown;
        Color c = new Color(12, 12, 12, 1);

        
        sr.material.color = Color.magenta;

        
        canMove = true;
        var main = deathVFX.GetComponent<ParticleSystem>().main;
        main.startColor = Color.cyan;

    }

    void Update()
    {
        Movement();
        Shooting();
        CheckForDeath(20f);
        DontOverlap();
    }

    private void Movement()
    {
        float currDist = Vector2.Distance(this.transform.position, target.position);

        ///Debug.Log(target.position);

        if (currDist > retreatDistance && currDist < followDistance)
        {
            //sweet spot
            this.transform.position = transform.position;
        }
        if (currDist >= followDistance)
        {
            //prea departe de player
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        if(currDist <= retreatDistance)
        {
            //prea aproape de player
            transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
        }
    }

    private void Shooting()
    {
       
        if (shootCooldown <= 0 && Vector2.Distance(this.transform.position,target.position)<20f)
        {
            //shoot


            StartCoroutine(ShootingSkill());

            /*if (nOfCorners == 3)

            {
                Instantiate(projectile, transform.position, transform.rotation);
                Instantiate(projectile, transform.position, transform.rotation);
                Instantiate(projectile, transform.position, transform.rotation);
                print(projectile.transform.position);
            }
            // projectile.gameObject.GetComponent<EnemyProjectile>().SetDir(distance);
            if (nOfCorners == 4)

            {1.
                Instantiate(projectile, transform.position, transform.rotation);
                Instantiate(projectile, transform.position, transform.rotation);
                Instantiate(projectile, transform.position, transform.rotation);
                Instantiate(projectile, transform.position, transform.rotation);
                print(projectile.transform.position);
            }
            if (nOfCorners == 4)

            {
                Instantiate(projectile, transform.position, transform.rotation);
                Instantiate(projectile, transform.position, transform.rotation);
                Instantiate(projectile, transform.position, transform.rotation);
                Instantiate(projectile, transform.position, transform.rotation);
                
                print(projectile.transform.position);
            }
            if(nOfCorners==10)
            {
                Instantiate(projectile, transform.position, transform.rotation);
                Instantiate(projectile, transform.position, transform.rotation);
                Instantiate(projectile, transform.position, transform.rotation);
                Instantiate(projectile, transform.position, transform.rotation);
                Instantiate(projectile, transform.position, transform.rotation);
                Instantiate(projectile, transform.position, transform.rotation);
                Instantiate(projectile, transform.position, transform.rotation);
                Instantiate(projectile, transform.position, transform.rotation);
                Instantiate(projectile, transform.position, transform.rotation);
                Instantiate(projectile, transform.position, transform.rotation);
            }*/

            shootCooldown = initCooldown;
        }
        else
        {
            shootCooldown -= Time.deltaTime;
        }
    }

    private void InitShape()
    {
        if (gameObject.CompareTag("SquareEnemy"))
        {
            projectile = pc.projectiles[2];
            nOfCorners = 4;
        }
        else if (gameObject.CompareTag("TriangleEnemy"))
        {
            projectile = pc.projectiles[3];
            nOfCorners = 3;
        }
        else if (gameObject.CompareTag("RhombEnemy"))
        {
            projectile = pc.projectiles[1];
            nOfCorners = 4;
        }
        else if (gameObject.CompareTag("CircleEnemy"))
        {
            projectile = pc.projectiles[0];
            nOfCorners = 10;
        }

       
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ExplosionParticle"))
        {
            Instantiate(deathVFX, this.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if (collision.tag == "Laser")
        {
            Instantiate(deathVFX, this.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if(collision.tag == "Sentinel")
        {
            Instantiate(deathVFX, this.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if (collision.tag.Contains("Enemy"))
        {
            return;
        }
        else if (collision.CompareTag("Player"))
        {
            Instantiate(deathVFX, this.transform.position, Quaternion.identity);
            player.TakeDamage(this.damage);
            Destroy(gameObject);
        }
        else if (this.tag == "TriangleEnemy")
        {
            if (collision.tag == "TriangleProjectile")
            {
                this.TakeDamage(player.damage);
                Destroy(collision.gameObject);
            }
            else
            {
                Destroy(collision.gameObject);
            }
        }
        else if (this.tag == "SquareEnemy")
        {
            if (collision.tag == "SquareProjectile")
            {
                this.TakeDamage(player.damage);
                Destroy(collision.gameObject);
            }
            else
            {
                Destroy(collision.gameObject);
            }
        }
        else if (this.tag == "RhombEnemy")
        {
            if (collision.tag == "RhombProjectile")
            {
                this.TakeDamage(player.damage);
                Destroy(collision.gameObject);
            }
            else
            {
                Destroy(collision.gameObject);
            }
        }
        else if (this.tag == "CircleEnemy")
        {
            if (collision.tag == "CircleProjectile")
            {
                this.TakeDamage(player.damage);
                Destroy(collision.gameObject);
            }
            else
            {
                Destroy(collision.gameObject);
            }
        }

    }

    private IEnumerator ShootingSkill()
    {
        int shots = 0;
        while(shots<nOfCorners)
        {
            shots++;
            Instantiate(projectile, transform.position, transform.rotation);
            yield return new WaitForSeconds(0.5f);
        }
    }

}
