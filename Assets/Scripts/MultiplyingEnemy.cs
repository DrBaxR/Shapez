using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplyingEnemy : Enemies
{

    public List<Transform> spawnPoints;
    public float timeBtwSpawns;
    public GameObject enemyPrefab;
    public int numberOfClonedTimes;
  


    private Transform target;
    private float startTimeBtwSpawns;

    // Start is called before the first frame update
    void Start()
    {
        startTimeBtwSpawns = timeBtwSpawns;
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        if(timeBtwSpawns<=0)
        {
            timeBtwSpawns = startTimeBtwSpawns;
            StartCoroutine(SpawnClones());
           
        }
        else { timeBtwSpawns -= Time.deltaTime; }
    }
    private IEnumerator SpawnClones()
    {
       
        int i=0;
        while(i<numberOfClonedTimes)
        {
            int randomPoint1 = UnityEngine.Random.Range(0, spawnPoints.Count);
            
            yield return StartCoroutine(Spawn(randomPoint1));
            i++;
        }
    }

    private IEnumerator Spawn(int randomPoint1)
    {
        Vector2 dir = spawnPoints[randomPoint1].position - transform.position;
        dir = dir.normalized;
        GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity) as GameObject;
        Rigidbody2D rb = enemy.gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce(dir*);
        yield return null;
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
}
