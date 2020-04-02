using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    private static int healAmount = 10;
    public float rotationSpeed = 5f;

    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotationSpeed * Time.deltaTime));
    }

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
