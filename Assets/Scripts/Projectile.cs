using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 dir;
    public float speed;
    private Player player;
    private Vector2 initialPos;
    // Start is called before the first frame update
    void Start()
    {
        Initialization();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(initialPos, this.transform.position) >= player.range)
            Destroy(this.gameObject);
    }

    public void SetDirection(Vector2 dir)
    {
        this.dir = dir;
    }
    private void Initialization()
    {

        rb = GetComponent<Rigidbody2D>();
        rb.velocity = dir * speed;
        initialPos = this.transform.position;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
}
