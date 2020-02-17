using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingEnemy : Enemies
{
    private Transform target;
    private Player player;
   

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        CheckForDeath();
        IncreaseAttributes(2, 2);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("SquareProjectile"))
        {
            this.TakeDamage(player.damage);
            Destroy(collision.gameObject);
        }
        if(collision.CompareTag("Player"))
        {
            player.health = this.DealDamage(player.health);
            Destroy(gameObject);
        }
    }

    private void CheckForDeath()
    {
        if (health <= 0)
            Destroy(gameObject);
    }
    
    public void TakeDamage(int damage)
    {
        this.health -= damage;
    }
    
}
