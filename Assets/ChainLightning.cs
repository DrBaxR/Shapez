using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainLightning : MonoBehaviour
{

    private int curveCount;
    private readonly int numberOfNodes = 50;
    private LineRenderer laser;
    private Vector3[] positionsLaser = new Vector3[200];
    // Start is called before the first frame update
    void Start()
    {
        laser = GetComponent<LineRenderer>();
        laser.enabled = false;
        laser.positionCount = numberOfNodes;

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
            laser.positionCount = 200;

           
            /* curveCount = (int)positions.Count/2;
             for(int j = 0;j<curveCount;j++)
             {
                 int nodeIndex = j * 2;
                 DrawQuadraticBezierCurve(positions[nodeIndex], CalculateTriangle(positions[nodeIndex], positions[nodeIndex+1]), positions[nodeIndex+1]);
             }*/


            for (int j = 0; j < hits.Length; j++)
            {
                DrawQuadraticBezierCurve(positions[j], CalculateTriangle(positions[j], positions[j + 1]), positions[j + 1]);

                /*laser.enabled = true;
                yield return new WaitForSeconds(0.5f);*/
                laser.enabled = true;
                yield return new WaitForSeconds(0.1f);

                laser.enabled = false;
                /*if (hits != null)
                {

                    if (hits[j].transform.tag.Contains("Enemy") && hits != null)
                    {
                        hits[j].gameObject.GetComponent<Enemies>().canMove = false;

                    }
                }*/
                if(hits!=null)
                foreach (Collider2D hit in hits)
                {
                    if (hit.transform.tag.Contains("Enemy") && hit != null)
                    {
                        hit.gameObject.GetComponent<Enemies>().canMove = false;


                    }
                }










            }
            yield return new WaitForSeconds(2f);
            if(hits!=null)
            foreach (Collider2D hit in hits)
            {
                if (hit.transform.tag.Contains("Enemy") && hit != null)
                {
                    hit.gameObject.GetComponent<Enemies>().canMove = true;


                }
            }
            // DrawQuadraticBezierCurve(positions[0], CalculateTriangle(positions[0], positions[1]), positions[1]);
            //curveCount = positions.Count / 3;
            Debug.Log(curveCount);


            //DrawCurve(positions);

            // laser.positionCount = positions.Count;
            // laser.SetPositions(positions.ToArray());
            /*  laser.enabled = true;
              yield return new WaitForSeconds(0.5f);

              laser.enabled = false;
              List<Vector2> initialVelocity = new List<Vector2>();
              int i = 0;
              if (hits != null)
                  foreach (Collider2D hit in hits)
                  {
                      if (hit.transform.tag.Contains("Enemy") && hit!=null)
                      {
                          hit.gameObject.GetComponent<Enemies>().canMove = false;

                      }
                  }
              yield return new WaitForSeconds(2f);
              i = 0;
              foreach (Collider2D hit in hits)
              {
                  if (hit.transform.tag.Contains("Enemy") && hit != null)
                  {
                      hit.gameObject.GetComponent<Enemies>().canMove = true;


                  }
              }



          }*/







        }
    }
    void DrawQuadraticBezierCurve(Vector3 point0, Vector3 point1, Vector3 point2)
    {
        
        float t = 0f;
        Vector3 B = new Vector3(0, 0, 0);
        laser.SetPosition(0, point0);

        for (int i = 1; i < laser.positionCount; i++)
        {
            B = (1 - t) * (1 - t) * point0 + 2 * (1 - t) * t * point1 + t * t * point2;
            laser.SetPosition(i, B);
            t += (1 / (float)laser.positionCount);
        }
    
}

   

   /* private void DrawCurve(List<Vector3> positions)
    {
       for (int j = 0; j < curveCount; j++)
        {
            for (int i = 1; i <= numberOfNodes; i++)
            {
                float t = (float)i / numberOfNodes;
                int nodeIndex = j * 3;
               // positionsLaser[i - 1] = CalculateCubicBezierPoint(t, positions[nodeIndex], p);
              
                //laser.SetPosition((j * numberOfNodes) + (i - 1), pixel);
            }
            
        }
        laser.SetPositions(positionsLaser);
    
    }*/

    private Vector3 CalculateTriangle(Vector3 a,Vector3 b)
    {
        Vector3 c = new Vector3(0, 0, 0);
        float distance = Vector2.Distance(a, b);
        c.x = (a.x + b.x + Mathf.Sqrt(3f) * (b.y - a.y)) / 2;
        c.y = (a.y + b.y + Mathf.Sqrt(3f) * (b.x - a.x)) / 2;
        return c;

    }

    private Vector3 CalculateCubicBezierPoint(float t,Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        float uuu = uu * u;
        float ttt = tt * t;

        Vector3 p = uuu * p0;
        p += 3 * uu * t * p1;
        p += 3 * u * tt * p2;
        p += ttt * p3;

        return p;
    }

    private Vector3 CalculateQuadraticBezierPoint(float t,Vector3 p0,Vector3 p1,Vector3 p2)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        Vector3 p = uu * p0;
        p += 2 * u * t * p1;
        p += tt * p2;
        return p;
    }

 /* public IEnumerator ChainLightningSkill()
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
             CalculateNodes(positions);



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







     }*/


   /* private void CalculateNodes(List<Vector3> positions)
    {
        curveCount = (int)positions.Count;

    }*/
}
