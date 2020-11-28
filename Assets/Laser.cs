using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public static bool laserUsed;
    public Transform hitPoint;

    private LineRenderer laser;
    private CapsuleCollider2D capsuleCollider;
     

    // Start is called before the first frame update
    void Start()
    {
        laser = GetComponent<LineRenderer>();
        laser.enabled = false;
        laser.useWorldSpace = true;
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        laserUsed = false;

    }

    // Update is called once per frame
    void LateUpdate()
    {
       
        laser.SetPosition(0, this.transform.position);
        laser.SetPosition(1, hitPoint.transform.position);
       // Debug.Log(capsuleCollider.direction);
        if (laserUsed)
        {
            StartCoroutine(LaserShot());
        }
        


    }

    private IEnumerator LaserShot()

    {
        capsuleCollider.enabled = true;
        if(capsuleCollider.direction == 0)
        capsuleCollider.size = new Vector2(0.5f, Vector2.Distance(hitPoint.position, this.transform.position));
        else
        {
            capsuleCollider.size = new Vector2(Vector2.Distance(hitPoint.position, this.transform.position), 0.5f);
        }

       // var hits = Physics2D.RaycastAll(this.transform.position, transform.up);
      

        laser.enabled = true;
        yield return new WaitForSeconds(1f);

        /*foreach (RaycastHit2D hit in hits)
            if (hit && hit.transform.tag != "Player")
            {
                Destroy(hit.collider.gameObject);
            }*/

        
        capsuleCollider.enabled = false;
        laser.enabled = false;
        //hits = Physics2D.RaycastAll(this.transform.position, transform.up);

        yield return new WaitForSeconds(1f);
        capsuleCollider.enabled = true;
        laser.enabled = true;
       

        /* foreach (RaycastHit2D hit in hits)
             if (hit && hit.transform.tag != "Player")
             {
                 Destroy(hit.collider.gameObject);
             }*/

        yield return new WaitForSeconds(1f);
        capsuleCollider.enabled = false;
        laser.enabled = false;
        laserUsed = false;
        

    }

}
