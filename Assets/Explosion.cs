using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject origin;
 void OnParticleCollision(GameObject other)
    {
        
        if (other.tag != origin.tag)
            Destroy(other.gameObject);
        else
        {
            print(other.gameObject.tag);
        }
    }
}
