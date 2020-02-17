using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemies : MonoBehaviour
{
    
    public int health;
    public int damage;
    public float timeUntillIncrease;
    
    public float speed;

    private float time=0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
}
