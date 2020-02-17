using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemies : MonoBehaviour
{

    public int health;
    public int damage;
    public float timeUntillIncrease;
    

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
        if (Time.time >= timeUntillIncrease)
        {
            timeUntillIncrease += 300f;
            this.damage += damage;
        }
    }
    public void IncreaseAttributes(int damage,int health)
    {
        if (Time.time >= timeUntillIncrease)
        {
            this.damage += damage;
            this.health += health;
        }
    }
}
