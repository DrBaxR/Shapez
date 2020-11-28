using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    public float timeBtwSpawns;
    public List<GameObject> powerUps;
    private float startTimeBtwSpawns;
    private Vector2 spawnPoint;
    
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
            spawnPoint = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), Camera.main.farClipPlane / 2));
            
            Instantiate(powerUps[Random.Range(0,powerUps.Count)], spawnPoint, Quaternion.identity);
            timeBtwSpawns = startTimeBtwSpawns;
        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }
    }
}
