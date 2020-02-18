using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeEnemy : Enemies
{
    public float dodgeSpeed = 1.0f;

    private Transform target;
    private Transform oldTarget;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        transform.up = target.position - transform.position;
        transform.Translate(Vector2.up * speed * Time.deltaTime, Space.Self);

        if(Input.GetMouseButtonDown(0))
        {
            Dodge();
        }

    }

    private void Dodge()
    {
        int rand = Random.Range(0, 2);
        Vector2 dir = new Vector2(1, 0);
        float t = Time.time + 1.0f;

        if (rand == 0)
        { 
            dir = dir * -1;   
        }

        transform.Translate(dir * dodgeSpeed, Space.Self);
    }
}
