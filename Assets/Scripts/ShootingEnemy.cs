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
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        initCooldown = shootCooldown;
        Color c = new Color(12, 12, 12, 1);

        
        sr.material.color = Color.magenta;

        InitShape();
        
    }

    void Update()
    {
        Movement();
        Shooting();
        CheckForDeath(20f);
    }

    private void Movement()
    {
        float currDist = Vector2.Distance(this.transform.position, target.position);

        Debug.Log(currDist);

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
        if (shootCooldown <= 0)
        {
            //shoot
           
           
            int shots = 0;
            while (shots < nOfCorners)
            {
                shots++;
                Instantiate(projectile, transform.position, transform.rotation);
               // projectile.gameObject.GetComponent<EnemyProjectile>().SetDir(distance);
            }

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
        if (this.tag == "TriangleEnemy")
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

}
