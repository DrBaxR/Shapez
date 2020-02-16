using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawer : MonoBehaviour
{
    public Waves[] waves;
    public float timeBtwSpawns;
    private float startTimeBtwSpawns;
    // Start is called before the first frame update
    void Start()
    {
        startTimeBtwSpawns = timeBtwSpawns;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwSpawns <= 0)
        {
            
            int index = Random.Range(0, waves.Length);
            for (int i = 0; i < waves[index].waypoints.Count; i++)
            {
                Instantiate(waves[index].enemy, waves[index].waypoints[i].transform.position, Quaternion.identity);
            }
            timeBtwSpawns = startTimeBtwSpawns;
        }
        else timeBtwSpawns -= Time.deltaTime;
    }
}
