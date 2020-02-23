using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplyingEnemy : Enemies
{

    public List<Transform> spawnPoints;
    public float timeBtwSpawns;
    public GameObject enemy;
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
        Instantiate(enemy, spawnPoints[randomPoint1].position, Quaternion.identity);
        yield return null;
    }
}
