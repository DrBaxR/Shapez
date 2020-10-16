using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemies : MonoBehaviour
{
    
    public int health;
    public int damage;
    public float timeUntillIncrease;
    public int scorePoints;

    public float speed;


    protected SpriteRenderer sr;
    public EnemySpriteContainer esc;
    public VFXContainer vfxC;

    protected GameObject deathVFX;

    protected AudioManager audioManager;

    private float time=0f;
    public bool canMove;


    private void Start()
    {
        
    }


    public void IncreaseAttributes(int damage)
    {
        time += Time.unscaledDeltaTime;
        if (time>= timeUntillIncrease)
        {
            time = 0f;
            this.damage += damage;
        }
    }
    public void IncreaseAttributes(int damage,int health)
    {
        time += Time.unscaledDeltaTime;
        if (time >= timeUntillIncrease)
        {
            time = 0f;
            this.damage += damage;
            this.health += health;
        }
    }

    public int DealDamage(int hpOfAttackedTarget)
    {
        return hpOfAttackedTarget - this.damage;
    }

    public void TakeDamage(int damage)
    {
        this.health -= damage;
    }

    protected void CheckForDeath(float experience)
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

    protected void Initialization()

  {
      int randomIndex = UnityEngine.Random.Range(0, esc.enemySprites.Count);
        //will remove this variable soon
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
      sr.sprite = esc.enemySprites[randomIndex];
     
      
      if (randomIndex == 0)
      {
          gameObject.tag = "SquareEnemy";
            deathVFX = vfxC.deathVFXs[randomIndex];
            var main = deathVFX.GetComponent<ParticleSystem>().main;
            main.startColor = this.GetComponent<SpriteRenderer>().material.color;
           
        }
      else if (randomIndex == 1)
      {
          gameObject.tag = "CircleEnemy";
            deathVFX = vfxC.deathVFXs[randomIndex];
            var main = deathVFX.GetComponent<ParticleSystem>().main;
            main.startColor = this.GetComponent<SpriteRenderer>().material.color;
        }
      else if (randomIndex == 2)
      {
          gameObject.tag = "TriangleEnemy";
          deathVFX = vfxC.deathVFXs[randomIndex];
            var main = deathVFX.GetComponent<ParticleSystem>().main;
            main.startColor = this.GetComponent<SpriteRenderer>().material.color;
        }
      else if (randomIndex == 3)
      {
          gameObject.tag = "RhombEnemy";
            deathVFX = vfxC.deathVFXs[randomIndex];
            var main = deathVFX.GetComponent<ParticleSystem>().main;
            main.startColor = this.GetComponent<SpriteRenderer>().material.color;
        }

      
  }

    public void DontOverlap()
    {
        string[] tagsToDisable =
              {
                "RhombEnemy",
                 "SquareEnemy",
                 "CircleEnemy",
                 "TriangleEnemy"
             };
        foreach (string tag in tagsToDisable)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(tag);




            foreach (GameObject enemy in enemies)
            {
                if (enemy != null)
                {
                    float currentDistance = Vector2.Distance(transform.position, enemy.transform.position);

                    if (currentDistance < 2.0f)
                    {
                        Vector3 dist = transform.position - enemy.transform.position;
                        transform.position += dist * Time.deltaTime;
                    }
                }
            }
        }
    }



}
