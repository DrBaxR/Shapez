using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sentinel : MonoBehaviour
{

    public GameObject bulletPrefab;
    public float timeBtwShots;
    private float startTimeBtwShots;
    private GameObject dir;
    public float activeTime;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        startTimeBtwShots = timeBtwShots;
        dir = null;
        //this.enabled = true;
        time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(time>=activeTime)
        {
            time = 0f;
            this.gameObject.SetActive(false);
            
        }
        else { time += Time.deltaTime; }
        FindEnemy();
        if (timeBtwShots <= 0 && dir!=null)
        {
            
            Shoot();
            timeBtwShots = startTimeBtwShots;
            dir = null;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }


    private void Shoot()
    {
        /*Vector2 direction = FindDirection();
        direction.x = direction.x - transform.position.x;
        direction.y = direction.y - transform.position.y;
        direction = direction.normalized;
       
        //myAudio.PlayAudio("laserAttack");
        SentinelProjectile proj = bullet.GetComponent<SentinelProjectile>();
        proj.SetDirection(direction);*/
        GameObject bullet = Instantiate(bulletPrefab, this.transform.position, Quaternion.identity) as GameObject;

    }

    private Vector2 FindDirection()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(this.transform.position, 10f);
        float min = 9999f;
        //GameObject auxProjectile;
        Vector2  directionTranform = new Vector2();
        if (hits != null)
        {

            {
                for (int i = 0; i < hits.Length; i++)
                {
                    if (Vector2.Distance(this.transform.position, hits[i].transform.position) < min && hits[i].transform.tag.Contains("Enemy") && !hits[i].transform.tag.Contains("Projectile"))
                    {
                        min = Vector2.Distance(this.transform.position, hits[i].transform.position);

                        directionTranform = hits[i].transform.position;



                    }
                }

            }


        }
        return directionTranform;
    }

    private void FindEnemy()
    {
        string[] tags =
        {
            "SquareEnemy",
            "CircleEnemy",
            "RhombEnemy",
            "TriangleEnemy"
        };
       
        foreach (string tag in tags)
        {
            dir = GameObject.FindGameObjectWithTag(tag);
        }
    }
}

