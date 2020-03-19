using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingEnemy : Enemies
{
    private Transform target;
    private Player player;
   // public EnemySpriteContainer esc;
  //  private SpriteRenderer sr;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        /*sr = GetComponent<SpriteRenderer>();
        Initialization();*/
        sr = GetComponent<SpriteRenderer>();
        Initialization();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        CheckForDeath();
        IncreaseAttributes(2, 2);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if(collision.CompareTag("Player"))
        {
            player.health = this.DealDamage(player.health);
            Destroy(gameObject);
        }

        if(this.tag == "TriangleEnemy")
        {
            if(collision.tag == "TriangleProjectile")
            {
                this.TakeDamage(player.damage);
                Destroy(collision.gameObject);
            }
        }
        if (this.tag == "SquareEnemy")
        {
            if (collision.tag == "SquareProjectile")
            {
                this.TakeDamage(player.damage);
                Destroy(collision.gameObject);
            }
        }
        if (this.tag == "RhombEnemy")
        {
            if (collision.tag == "RhombProjectile")
            {
                this.TakeDamage(player.damage);
                Destroy(collision.gameObject);
            }
        }
        if (this.tag == "CircleEnemy")
        {
            if (collision.tag == "CircleProjectile")
            {
                this.TakeDamage(player.damage);
                Destroy(collision.gameObject);
            }
        }
        /*if (collision.CompareTag("ExplosionParticle"))
        {
            Destroy(gameObject);
        }*/
    }
/*  public void Initialization()

    {
        int randomIndex = Random.Range(0, esc.enemySprites.Count);
        sr.sprite = esc.enemySprites[randomIndex];
        if (randomIndex == 0)
        {
            gameObject.tag = "SquareEnemy";
        }
        else if (randomIndex == 1)
        {
            gameObject.tag = "CircleEnemy";
        }
        else if (randomIndex == 2)
        {
            gameObject.tag = "TriangleEnemy";
        }
        else if (randomIndex == 3)
        {
            gameObject.tag = "RhombEnemy";
        }
    }*/



}
