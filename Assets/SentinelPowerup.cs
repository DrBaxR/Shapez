using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentinelPowerup : MonoBehaviour
{
   
    public List<GameObject> sentinels;
    private float timeActive;
    // Start is called before the first frame update
    void Start()
    {
        timeActive = 0f;

    }

    // Update is called once per frame
    void Update()
    {
       if(timeActive>=15f)
        {
            Destroy(gameObject);
        }
        else
        {
            timeActive += Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
            foreach (GameObject sentinel in sentinels)
            {
                sentinel.SetActive(true);
            }
            Destroy(gameObject);
        
    }
}
