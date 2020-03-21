using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportingTriangleEnemy : Enemies
{

    public float explosionRadius;
    public Transform explosionCenter;
    //  public EnemySpriteContainer esc;

    public Player player;

    private float minRadius = 2;
    private float maxRadius = 3;
    private Transform target;
    private bool moving;
    private float nextTeleport;
    //private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        moving = true;
        nextTeleport = 0;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        /* sr = GetComponent<SpriteRenderer>();
         Initialization();*/
        sr = GetComponent<SpriteRenderer>();
        Initialization();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Teleport();
        CheckForDeath();

    }


    private void Move()
    {
        if (moving)
            transform.position = Vector2.MoveTowards(this.transform.position, target.position, this.speed * Time.deltaTime);
    }

    private void Teleport()
    {
        if (nextTeleport > 5f)
        {
            Vector3 randomPos = UnityEngine.Random.insideUnitCircle * (maxRadius - minRadius);
            this.transform.position = target.position + randomPos.normalized * minRadius + randomPos;
            StartCoroutine(SetMoving());
            nextTeleport = 0;


        }

        else if (Vector2.Distance(transform.position, target.position) < 2f)
        {
            StartCoroutine(SetMoving());
        }

        else
        {
            nextTeleport += Time.deltaTime;


        }
    }






    private IEnumerator SetMoving()
    {
        moving = false;
        yield return StartCoroutine(Explosion());
        moving = true;

    }

    private IEnumerator Explosion()
    {
        yield return new WaitForSeconds(0.5f);
        Collider2D[] hits = Physics2D.OverlapCircleAll(explosionCenter.position, explosionRadius);

        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].gameObject.tag == "Player")
            {
                Player playerController = hits[i].gameObject.GetComponent<Player>();
                playerController.TakeDamage(this.damage);
            }
            else
            {
                Destroy(hits[i].gameObject);
            }
            Destroy(this.gameObject);

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*
        if (collision.CompareTag("TriangleProjectile"))
        {
            this.TakeDamage(GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().damage);
            Destroy(collision.gameObject);
        }
        */

        if (collision.CompareTag("Player"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().health = this.DealDamage(this.damage);
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
        
        /* if (collision.CompareTag("ExplosionParticle"))
         {
             Destroy(gameObject);
         }*/
    }

    /*public void Initialization()

    {
        int randomIndex = UnityEngine.Random.Range(0, esc.enemySprites.Count);
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
