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
    
    private Player player;
   // private new AudioManager audioManager;

    public static float time=0f;
   
    // public EnemySpriteContainer esc;
    //private SpriteRenderer sr;


    public static Sprite currentSprite;
    private Transform target;
    private float startTimeBtwSpawns;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        startTimeBtwSpawns = timeBtwSpawns;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        //audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        /* sr = GetComponent<SpriteRenderer>();
         Initialization();*/
        sr = GetComponent<SpriteRenderer>();
        
        Initialization();
        sr.material.color = Color.red;
        currentSprite = this.sr.sprite;
        
    }


    // Update is called once per frame
    void Update()
    {
       // enemyPrefab.GetComponent<SpriteRenderer>().sprite = this.sr.sprite;
      /* if(health<=0)
        {
            GameManager.scorel += scorePoints;
            LevelSystem.UpdateExperience(30f);
            this.audioManager.PlaySound("deathSound");
            Instantiate(deathVFX, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }*/
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        CheckForDeath(30f);
        if (timeBtwSpawns<=0)
        {
            timeBtwSpawns = startTimeBtwSpawns;
            StartCoroutine(SpawnClones());
           
        }
        else { timeBtwSpawns -= Time.deltaTime; }
        time -= Time.deltaTime;
       // print(time);
       
        
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
       // enemyPrefab.GetComponent<SpriteRenderer>().sprite = currentSprite;
        GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity) as GameObject;
        
        //enemy.gameObject.GetComponent<SpriteRenderer>().sprite = this.sr.sprite;
        Rigidbody2D rb = enemy.gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce(dir*30f);
        yield return null;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {


        /*if (collision.CompareTag("Player"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().health = this.DealDamage(this.damage);
        }*/


        if (collision.CompareTag("Player"))
        {
            player.health = this.DealDamage(player.health);
            Destroy(gameObject);
        }

        else if (this.tag == "TriangleEnemy")
        {
            if (collision.tag == "TriangleProjectile")
            {
                this.TakeDamage(player.damage);
                Destroy(collision.gameObject);
            }
            else if (collision.tag.Contains("Projectile") && !collision.tag.Contains("Enemy"))
            {
                Destroy(collision.gameObject);
            }
        }
        else if (this.tag == "SquareEnemy")
        {
            if (collision.tag == "SquareProjectile")
            {
                this.TakeDamage(player.damage);
                Destroy(collision.gameObject);
            }
            else if(collision.tag.Contains("Projectile") && !collision.tag.Contains("Enemy"))
            {
                Destroy(collision.gameObject);
            }
        }
        else if (this.tag == "RhombEnemy")
        {
            if (collision.tag == "RhombProjectile")
            {
                this.TakeDamage(player.damage);
                Destroy(collision.gameObject);
            }
            else if (collision.tag.Contains("Projectile") && !collision.tag.Contains("Enemy"))
            {
                Destroy(collision.gameObject);
            }
        }
        else if (this.tag == "CircleEnemy")
        {
            if (collision.tag == "CircleProjectile")
            {
                this.TakeDamage(player.damage);
                Destroy(collision.gameObject);
            }
            else if (collision.tag.Contains("Projectile") && !collision.tag.Contains("Enemy"))
            {
                Destroy(collision.gameObject);
            }
        }
        
    }
public new void Initialization()

{
      
        if (time<=0f)
        {
            int randomIndex = UnityEngine.Random.Range(0, esc.enemySprites.Count);
            audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
            sr.sprite = esc.enemySprites[randomIndex];
            int randomIndexVFX = UnityEngine.Random.Range(0, vfxC.deathVFXs.Count);
            //deathVFX = vfxC.deathVFXs[randomIndexVFX];
            if (randomIndex == 0)
            {
                gameObject.tag = "SquareEnemy";
                deathVFX = vfxC.deathVFXs[randomIndex];
                var main = deathVFX.GetComponent<ParticleSystem>().main;
                main.startColor = Color.red;
            }
            else if (randomIndex == 1)
            {
                gameObject.tag = "CircleEnemy";
                deathVFX = vfxC.deathVFXs[randomIndex];
                var main = deathVFX.GetComponent<ParticleSystem>().main;
                main.startColor = Color.red;
            }
            else if (randomIndex == 2)
            {
                gameObject.tag = "TriangleEnemy";
                deathVFX = vfxC.deathVFXs[randomIndex];
                var main = deathVFX.GetComponent<ParticleSystem>().main;
                main.startColor = Color.red;
            }
            else if (randomIndex == 3)
            {
                gameObject.tag = "RhombEnemy";
                deathVFX = vfxC.deathVFXs[randomIndex];
                var main = deathVFX.GetComponent<ParticleSystem>().main;
                main.startColor = Color.red;
            }
            //currentSprite = this.sr.sprite;
            time = 30f;
        }
        else
        {
            this.sr.sprite = currentSprite;
           
        }
    
   }
    protected new void CheckForDeath(float experience)
    {
        
        
            if (health <= 0)
            {
                GameManager.scorel += scorePoints;
                LevelSystem.UpdateExperience(experience);
                audioManager.PlaySound("deathSound");
                Instantiate(deathVFX, this.transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        
    }
}
