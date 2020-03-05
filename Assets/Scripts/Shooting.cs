using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform explosion;
    public float forceRatio;
    public GameObject bulletPrefab;
    public Weapon daniel;
    public GameObject expVFX;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Shootno();
        // StartCoroutine(Shoot());
    }

    private void Shootno()
    {
        if (Input.GetMouseButtonDown(0))
        {
            daniel.Shoot(this.transform);
           // daniel.projectile.GetComponent<Projectile>();
            /*Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position;
            direction = direction.normalized;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            GameObject bullet = Instantiate(bulletPrefab, this.transform.position, rotation) as GameObject;
            //myAudio.PlayAudio("laserAttack");
            Projectile proj = bullet.GetComponent<Projectile>();
            proj.SetDirection(direction);*/
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {

            // Instantiate(explVFX, transform.position, Quaternion.identity);



            Collider2D[] col = Physics2D.OverlapCircleAll(explosion.position, 5);
            for (int i = 0; i < col.Length; i++)
            {
                Instantiate(expVFX, this.transform.position, Quaternion.identity);
                if (col[i].gameObject.CompareTag("RhombEnemy"))

                {
                    Debug.Log("Rhomb");
                    Destroy(col[i].gameObject);
                }
                else if (col[i].gameObject.CompareTag("SquareEnemy"))
                {
                    Debug.Log("Square");
                    Destroy(col[i].gameObject);
                }
                else if (col[i].gameObject.CompareTag("TriangleEnemy"))
                {
                    Debug.Log("Triangle");
                    Destroy(col[i].gameObject);
                }
                else if (col[i].gameObject.CompareTag("CircleEnemy"))
                {
                    Debug.Log("Circle");
                    Destroy(col[i].gameObject);
                }



                    // else 
                }


            }
    }


    private IEnumerator Shoot()
    {
        while (true)
        {
            while (Input.GetMouseButtonDown(0))
            {

                Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position;
                direction = direction.normalized;
                GameObject bullet = Instantiate(bulletPrefab, this.transform.position, Quaternion.identity) as GameObject;
                //myAudio.PlayAudio("laserAttack");
                Projectile proj = bullet.GetComponent<Projectile>();
                proj.SetDirection(direction);

                yield return new WaitForSeconds(0.5f);
            }
            yield return new WaitForEndOfFrame();



        }
        /*if (Input.GetMouseButtonDown(0) && canShoot)
        {
            Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position;
            direction = direction.normalized;
            //direction.Normalize();
            GameObject bullet = Instantiate(bulletPrefab, this.transform.position, Quaternion.identity) as GameObject;
            myAudio.PlayAudio("laserAttack");
            //Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            Projectile proj =bullet.GetComponent<Projectile>();
            proj.SetDirection(direction);
            StartCoroutine(Fire());
            // rb.velocity = direction * forceRatio;
            // rb.AddForce(direction * forceRatio); cu asta mere,dar e cam ciudat
            // Debug.Log(rb.velocity.magnitude);
        }*/
    }
}

