using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : Enemies
{
    public float followDistance;
    public float retreatDistance;
    public float speed;
    public float shootCooldown;
    public ProjectileContainer pc;

    private SpriteRenderer rend;
    private Transform player;
    private float initCooldown = 0.0f;
    private GameObject projectile;
    private int nOfCorners;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        initCooldown = shootCooldown;
        Color c = new Color(12, 12, 12, 1);

        rend = gameObject.GetComponent<SpriteRenderer>();
        rend.material.color = Color.magenta;

        InitShape();
    }

    void Update()
    {
        Movement();
        Shooting();
    }

    private void Movement()
    {
        float currDist = Vector2.Distance(this.transform.position, player.position);

        Debug.Log(currDist);

        if (currDist > retreatDistance && currDist < followDistance)
        {
            //sweet spot
            this.transform.position = transform.position;
        }
        if (currDist >= followDistance)
        {
            //prea departe de player
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        if(currDist <= retreatDistance)
        {
            //prea aproape de player
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
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
            nOfCorners = 1000;
        }
    }
}
