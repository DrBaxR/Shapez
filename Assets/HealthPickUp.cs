using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : Powerup
{
    private static int healAmount = 10;
   

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player p = collision.GetComponent<Player>();
            p.Heal(healAmount);
            Destroy(gameObject);
        }
    }
}
