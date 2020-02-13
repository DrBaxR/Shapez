﻿    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public float forceRatio;
    public GameObject bulletPrefab;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Shoot());
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
