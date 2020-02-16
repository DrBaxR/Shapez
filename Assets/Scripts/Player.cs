using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float range;

    private float moveInputX;
    private float moveInputY;

    private Vector2 movementDirection;
    private Rigidbody2D rb;

    void Start()
    {
        //the comment that i added
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        moveInputX = Input.GetAxisRaw("Horizontal");
        moveInputY = Input.GetAxisRaw("Vertical");
        movementDirection = new Vector2(moveInputX , moveInputY);
        movementDirection.Normalize();
        rb.velocity = movementDirection * speed ;
       // Debug.Log(rb.velocity.magnitude);

       /* if (Input.GetKey(KeyCode.D))
        { rb.velocity += Vector2.right * speed * Time.deltaTime; }
         if (Input.GetKey(KeyCode.A)) {
            
            rb.velocity += -Vector2.right * speed * Time.deltaTime; 
        }
         if (Input.GetKey(KeyCode.W))
        {

            rb.velocity += Vector2.up * speed * Time.deltaTime;
        }
         if (Input.GetKey(KeyCode.S))
        {

            rb.velocity += Vector2.down * speed * Time.deltaTime;
        }*/

        //rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -speed, speed), Mathf.Clamp(rb.velocity.y, -speed, speed));
    }
}
