using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : ActiveSkills
{
    private CircleCollider2D circle;
   // private BoxCollider2D boxCollider;
    public float finalSize = 2f;
    public float increaseSpeed = 5;

    private void Start()
    {
        //boxCollider = GetComponent<BoxCollider2D>();
        circle = GetComponent<CircleCollider2D>();
        //this.isReady = false;
    }

    private void Update()
    {

        float radius = circle.radius;
        if(radius<finalSize)
        {
            radius += increaseSpeed * Time.deltaTime; 
            if(radius>finalSize)
            {
                radius = finalSize;
            }
            circle.radius = radius;
        }

        
       // Vector2 bSize = boxCollider.size;
       /* if(bSize.x<finalSize )
        {
            bSize += Vector2.one * increaseSpeed*Time.deltaTime ;
            if(bSize.x>finalSize)
            {
                bSize = new Vector2(finalSize, finalSize);
            }
            boxCollider.size = bSize;
        }*/


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag!="Player")
        {
            Destroy(collision.gameObject);
        }
    }
}
