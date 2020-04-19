using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

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

    }

    // Update is called once per frame
    void Update()
    {
       
        laser.SetPosition(0, this.transform.position);
        laser.SetPosition(1, hitPoint.transform.position);
        if (Input.GetKey(KeyCode.R))
        {
            StartCoroutine(LaserShot());
        }
        


    }

    private IEnumerator LaserShot()

    {
        capsuleCollider.enabled = true;
        capsuleCollider.size = new Vector2(0.5f, Vector2.Distance(hitPoint.position, this.transform.position));

       // var hits = Physics2D.RaycastAll(this.transform.position, transform.up);
      

        laser.enabled = true;

        /*foreach (RaycastHit2D hit in hits)
            if (hit && hit.transform.tag != "Player")
            {
                Destroy(hit.collider.gameObject);
            }*/

        yield return new WaitForSeconds(2f);
        capsuleCollider.enabled = false;
        laser.enabled = false;
        //hits = Physics2D.RaycastAll(this.transform.position, transform.up);

        yield return new WaitForSeconds(2f);
        laser.enabled = true;
       /* foreach (RaycastHit2D hit in hits)
            if (hit && hit.transform.tag != "Player")
            {
                Destroy(hit.collider.gameObject);
            }*/

        yield return new WaitForSeconds(2f);
        capsuleCollider.enabled = false;
        laser.enabled = false;
        

    }

}
