using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    public Transform hitPoint;

    private LineRenderer laser;
    

    // Start is called before the first frame update
    void Start()
    {
        laser = GetComponent<LineRenderer>();
        laser.enabled = false;
        laser.useWorldSpace = true;

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, hitPoint.position);
        if(hit)
        {
            Debug.Log(hit.transform.tag);
        }
        laser.SetPosition(0, this.transform.position);
        laser.SetPosition(1, hitPoint.transform.position);
        if (Input.GetKey(KeyCode.R))
        {
            StartCoroutine(LaserShot(hit));
        }
      
    }

    private IEnumerator LaserShot(RaycastHit2D hit)
    {


        laser.enabled = true;
        if (hit)
        {
            if (hit.transform.tag!="Player")
            {
                Destroy(hit.collider.gameObject);
            }
        }
        yield return new WaitForSeconds(2f);
        laser.enabled = false;
        yield return new WaitForSeconds(2f);
        laser.enabled = true;
        if (hit)
        {
            if (hit.transform.tag!="Player")
            {
                Destroy(hit.collider.gameObject);
            }
        }
        yield return new WaitForSeconds(2f);
        laser.enabled = false;

    }
}
