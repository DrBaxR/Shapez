using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainLightning : MonoBehaviour
{
    private LineRenderer laser;
    // Start is called before the first frame update
    void Start()
    {
        laser = GetComponent<LineRenderer>();
        laser.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator ChainLightningSkill()
    {

        List<Vector3> positions = new List<Vector3>();
        Collider2D[] hits = Physics2D.OverlapCircleAll(this.transform.position, 10f);
        if (hits != null)
        {
            positions.Add(this.transform.position);
            Vector3 previousPos = this.transform.position;
            foreach (Collider2D hit in hits)
            {



                positions.Add(hit.gameObject.transform.position);

            }

            laser.positionCount = positions.Count;
            laser.SetPositions(positions.ToArray());
            laser.enabled = true;
            yield return new WaitForSeconds(0.5f);

            laser.enabled = false;
            List<Vector2> initialVelocity = new List<Vector2>();
            int i = 0;
            if (hits != null)
                foreach (Collider2D hit in hits)
                {
                    if (hit.transform.tag.Contains("Enemy"))
                    {
                        hit.gameObject.GetComponent<Enemies>().canMove = false;

                    }
                }
            yield return new WaitForSeconds(2f);
            i = 0;
            foreach (Collider2D hit in hits)
            {
                if (hit.transform.tag.Contains("Enemy"))
                {
                    hit.gameObject.GetComponent<Enemies>().canMove = true;


                }
            }



        }




    }
}
