using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFollowingPowerup : MonoBehaviour
{
    private Transform player;
    private List<Transform> targets;
    public List<GameObject> projectiles;
    private List<GameObject> auxProjectiles = new List<GameObject>();
    public List<Transform> spawnPoints;


    [HideInInspector]
    public bool isActive;

    private bool isSpawned;



    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
        isSpawned = false;
        auxProjectiles = projectiles;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
       
        if(isSpawned)
        SendAtEnemy();
        Debug.Log(isSpawned);
    }


    private void Spawn()
    {

             isSpawned = true;
            for(int i=0;i<=projectiles.Count;i++)
            Instantiate(auxProjectiles[i], spawnPoints[i].position, Quaternion.identity);
       


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Spawn();
            
        }
    }

    private GameObject pop()
    {
        GameObject result = auxProjectiles[0];
        for (int i = 0; i <=auxProjectiles.Count; i++)
        {
            auxProjectiles[i] = auxProjectiles[i + 1];
        }
        auxProjectiles.Remove(auxProjectiles[auxProjectiles.Count]);
        return result;

    }

    private void SendAtEnemy()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(player.position, 10f);
        float min = -9999f;
        //GameObject auxProjectile;
        Transform directionTranform=null;
        if (hits != null)
        {
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < hits.Length; i++)
                {
                    if (Vector2.Distance(auxProjectiles[i].gameObject.transform.position, hits[i].transform.position) < min && hits[i].transform.tag.Contains("Enemy") && !hits[i].transform.tag.Contains("Projectile"))
                    {
                        min = Vector2.Distance(auxProjectiles[i].transform.position, hits[i].transform.position);

                        directionTranform = hits[i].transform;



                    }
                }
                auxProjectiles[j].gameObject.GetComponent<ShieldProjectile>().SendDirection(directionTranform);
                auxProjectiles.Remove(auxProjectiles[j]);
                break;
               
            }

        }
        /* auxProjectile = pop();
        if (hits != null) { }
        for (int i = 0; i < hits.Length; i++)
        {
            if (Vector2.Distance(auxProjectile.gameObject.transform.position, hits[i].transform.position) < min && hits[i].transform.tag.Contains("Enemy") && !hits[i].transform.tag.Contains("Projectile"))
            {
                min = Vector2.Distance(auxProjectile.transform.position, hits[i].transform.position);

                directionTranform = hits[i].transform;



            }

        }*/


    }
    
        
       
      
       }
        

   

