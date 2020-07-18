using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldProjectile : MonoBehaviour
{
    public float rotateSpeed;
    public float movementSpeed;
    private Transform target;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        target = null;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
            transform.position = Vector2.MoveTowards(this.transform.position, target.position, movementSpeed * Time.deltaTime);
        Debug.Log(target);
       // else
      //  transform.RotateAround(player.position, Vector3.forward, rotateSpeed * Time.deltaTime);
    }

    public void SendDirection(Transform direction)
    {
        target = direction;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Contains("En"))
        {
            Destroy(this.gameObject);
        }
    }
}
