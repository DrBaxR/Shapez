using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportingTriangleEnemy : Enemies
{

    public float explosionRadius;
    public Transform explosionCenter;

    private float minRadius = 2;
    private float maxRadius = 3;
    private Transform player;
    private bool moving;
    private float nextTeleport;
    
    // Start is called before the first frame update
    void Start()
    {
        moving = true;
        nextTeleport = 0;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Teleport();
        
    }


    private void Move()
    {
        if (moving)
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, this.speed * Time.deltaTime);
    }

    private void Teleport()
    {
        if (nextTeleport > 5f)
        {
            Vector3 randomPos = UnityEngine.Random.insideUnitCircle * (maxRadius - minRadius);
            this.transform.position = player.position+ randomPos.normalized*minRadius+randomPos;
            StartCoroutine(SetMoving());
            nextTeleport = 0;


        }

        else if (Vector2.Distance(transform.position, player.position) < 2f)
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
        
        for(int i =0;i<hits.Length;i++)
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
}
