using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    public float speed = 5.0f;
    public float lifeTime = 5.0f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.forward * speed * Time.deltaTime;
        Destroy(gameObject, lifeTime);
    }
}
