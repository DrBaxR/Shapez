using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeEnemy : Enemies
{
    public float dodgeSpeed = 1.0f;

    private Transform target;
    private Transform oldTarget;
    private Rigidbody2D rb;


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.up = target.position - transform.position;
        transform.Translate(Vector2.up * speed * Time.deltaTime, Space.Self);

        /*if (Input.GetMouseButtonDown(0))
        {
            Dodge();
        }*/
        DodgeProjectile();

    }

    private void Dodge()
    {
        int rand = Random.Range(0, 2);
        Vector3 dir = new Vector3(1, 0, 0);
        float t = Time.time + 1.0f;

        if (rand == 0)
        {
            dir = dir * -1;
        }

        // transform.Translate(dir * dodgeSpeed, Space.Self);
        transform.position = dir * dodgeSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CircleProjectile"))
        {
            this.TakeDamage(GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().damage);
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Player"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().health = this.DealDamage(this.damage);
        }
    }

    private void DodgeProjectile()

    {
        string[] tagsToDisable =
             {
                 "SquareProjectile",
                 "TriangleProjectile",
                 "CircleProjectile",
                 "RhombProjectile"
             };
        foreach (string tag in tagsToDisable)
        {
            GameObject[] projectiles = GameObject.FindGameObjectsWithTag(tag);




            foreach (GameObject projectile in projectiles)
            {
                if (projectile != null)
                {
                    float currentDistance = Vector2.Distance(transform.position, projectile.transform.position);

                    if (currentDistance < 6.0f)
                    {
                        Vector3 dist = transform.position - projectile.transform.position;
                        //transform.position += dist * Time.deltaTime;*/
                        float xOffset = 3f;
                        float yOffset = 3f;
                         dist = new Vector3(dist.x + xOffset, dist.y + yOffset, dist.z);
                        transform.position += dist * Time.deltaTime;



                        // rb.AddForce(dist);

                    }
                }
            }
        }
    }
}
