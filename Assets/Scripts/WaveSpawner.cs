using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Buna siua coae
public class WaveSpawner : MonoBehaviour
{
    [Header("Setup")] //atribute legate setup
    public EnemyContainer enemies = null;
    public float distanceX = 10.0f;
    public float distanceY = 6.0f;
    public int numSpawnPointsX = 9; //numarul de spawn point-uri pe x
    public int numSpawnPointsY = 5; //numarul de spawn point-uri pe y

    [Header("Spawner Parameters")] //atribute legate de gameplay
    [Space]
    public float timeBtwnWaves = 10.0f;
    public int enemiesPerWave = 5;

    private Transform[] spawnPoints; //contine toate spawnpoint-urile
    private bool[] used; //informatoa daca indicele i a fost folosit
    private int numSpawnPoints = 0;
    private float nextWave = 0.0f;

    void Start()
    {
        InitSpawnPoints();
    }
    void Update()
    {
        Debug.Log("asaf");
        if (Time.time > nextWave)
            SpawnWave();
    }

    private void SpawnWave() //spawneaza un wave de inamici
    {
        int i = 0;

        nextWave = Time.time + timeBtwnWaves;
        while (i < enemiesPerWave)
        {
            int index = Random.Range(0, spawnPoints.Length);
            if (!used[index])
            {
                i++;
                used[index] = true;
                int e = Random.Range(0, enemies.enemies.Capacity); //select the enemy to spawn
                Instantiate(enemies.enemies[e], spawnPoints[index].position, Quaternion.identity);
            }
        }

        InitUsed();
    }

    private void InitSpawnPoints() //initializeaza vectorul de spawnpoint-uri
    {
        int index = 0;
        float distX = 2 * distanceX / (numSpawnPointsX - 1);
        float distY = 2 * distanceY / (numSpawnPointsY - 1);

        numSpawnPoints = 2 * numSpawnPointsX + 2 * numSpawnPointsY - 4;
        spawnPoints = new Transform[numSpawnPoints];
        used = new bool[numSpawnPoints];
        InitUsed();

        GameObject emptyObject = new GameObject("SpawnPoint");

        //left
        for (int i = 0; i < numSpawnPointsY - 1; ++i)
        {
            spawnPoints[index] = Instantiate(emptyObject, new Vector2(-distanceX, -distanceY + i * distY), Quaternion.identity).transform;
            spawnPoints[index].parent = gameObject.transform;
            index++;
        }

        //top
        for (int i = 0; i < numSpawnPointsX - 1; ++i)
        {
            spawnPoints[index] = Instantiate(emptyObject, new Vector2(-distanceX + i * distX, distanceY), Quaternion.identity).transform;
            spawnPoints[index].parent = gameObject.transform;
            index++;
        }

        //right
        for (int i = 0; i < numSpawnPointsY - 1; ++i)
        {
            spawnPoints[index] = Instantiate(emptyObject, new Vector2(distanceX, distanceY - i * distY), Quaternion.identity).transform;
            spawnPoints[index].parent = gameObject.transform;
            index++;
        }

        //bot
        for (int i = 0; i < numSpawnPointsX - 1; ++i)
        {
            spawnPoints[index] = Instantiate(emptyObject, new Vector2(distanceX - i * distX, -distanceY), Quaternion.identity).transform;
            spawnPoints[index].parent = gameObject.transform;
            index++;
        }

        //destroy the first game object
        Destroy(emptyObject);
    }

    private void InitUsed()
    { 
        for(int i = 0; i < used.Length; ++i)
        {
            used[i] = false;
        }
    }
}
