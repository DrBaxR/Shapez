using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingEnemy : Enemies
{
    private Transform target;
    private Player player;
    public VFXContainer vfxC;
    // public EnemySpriteContainer esc;
    //  private SpriteRenderer sr;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        /*sr = GetComponent<SpriteRenderer>();
        Initialization();*/
        sr = GetComponent<SpriteRenderer>();
        sr.material.color = Color.blue;
        Initialization();
        if(gameObject.tag == "SquareEnemy")
        {
            deathVFX = vfxC.deathVFXs[0];
        }
        if (gameObject.tag == "CircleEnemy")
        {
            deathVFX = vfxC.deathVFXs[1];
        }
        if (gameObject.tag == "TriangleEnemy")
        {
            deathVFX = vfxC.deathVFXs[2];
        }
        if (gameObject.tag == "RhombEnemy")
        {
            deathVFX = vfxC.deathVFXs[3];
        }
        canMove = true;
        //var main = deathVFX.GetComponent<ParticleSystem>().main;
       // deathVFX.GetComponent<ParticleSystem>().startColor = Color.blue ;
        // main.startColor = Color.blue ;

    }

    void Update()
    {
        if (canMove)
        { transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            DontOverlap();
        }
        CheckForDeath(10f);
        IncreaseAttributes(2, 2);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
                
       if(collision.CompareTag("ExplosionParticle"))
        {
            Instantiate(deathVFX, this.transform.position, Quaternion.identity);
            Destroy(gameObject);

        }
        else if (collision.tag == "Laser")
        {
            Instantiate(deathVFX, this.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
       else if (collision.tag.Contains("Enemy"))
        {
            return;
        }
       else if(collision.CompareTag("Sentinel"))
        {
            Instantiate(deathVFX, this.transform.position, Quaternion.identity);
            Destroy(gameObject);
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
