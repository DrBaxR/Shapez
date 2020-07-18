using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentinelProjectile : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 direction;
    public float speed;
    private Transform player;
    private Transform dir;
    // Start is called before the first frame update
    void Start()
    {
        dir = null;
        Initialization();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetDirection(Vector2 direction)
    {
        this.direction = direction;
    }

    public void Initialization()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        dir = FindClosest();
        if (dir != null)
        {
            Vector2 direction = dir.position - this.transform.position;
            direction = direction.normalized;
            Debug.Log(direction);
            rb.velocity = direction * speed;
        }

    }

       public Transform FindDirection()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(player.position, 20f);
        float min = 9999f;
        //GameObject auxProjectile;
        Transform directionTranform =null;
        if (hits != null)
        {

            {
                for (int i = 0; i < hits.Length; i++)
                {
                    if (Vector2.Distance(this.transform.position, hits[i].transform.position) < min && hits[i].transform.tag.Contains("Enemy") && !hits[i].transform.tag.Contains("Projectile"))
                    {
                        min = Vector2.Distance(this.transform.position, hits[i].transform.position);

                        directionTranform = hits[i].transform;



                    }
                }

            }


        }
        return directionTranform;
    }
    private Transform FindClosest()
    {
        string[] tags =
        {
            "SquareEnemy",
            "CircleEnemy",
            "RhombEnemy",
            "TriangleEnemy"
        };
        List<GameObject> enemies=new List<GameObject>();
        foreach(string tag in tags)
        {
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tag);
            foreach (GameObject gameObj in gameObjects)
            {
                enemies.Add(gameObj);
            }
        }
        float min = 9999f;
        Transform dir = null;
        foreach(GameObject enemy in enemies)
        {
            if (Vector2.Distance(enemy.transform.position, this.transform.position) < min)
            {

                min = Vector2.Distance(enemy.transform.position, this.transform.position);
                dir = enemy.transform;
            }
        }
        return dir;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Contains("Enemy") || collision.tag.Contains("Projectile"))
        {
            Destroy(collision.gameObject);
        }
    }
}
