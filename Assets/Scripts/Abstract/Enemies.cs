using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemies : MonoBehaviour
{
    
    public int health;
    public int damage;
    public float timeUntillIncrease;
    
    public float speed;


    protected SpriteRenderer sr;
    public EnemySpriteContainer esc;

    private float time=0f;


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

    protected void CheckForDeath()
    {
        if (health <= 0)
            Destroy(gameObject);
    }

    protected void Initialization()

  {
      int randomIndex = UnityEngine.Random.Range(0, esc.enemySprites.Count);
      sr.sprite = esc.enemySprites[randomIndex];
      if (randomIndex == 0)
      {
          gameObject.tag = "SquareEnemy";
      }
      else if (randomIndex == 1)
      {
          gameObject.tag = "CircleEnemy";
      }
      else if (randomIndex == 2)
      {
          gameObject.tag = "TriangleEnemy";
      }
      else if (randomIndex == 3)
      {
          gameObject.tag = "RhombEnemy";
      }

      
  }



}
