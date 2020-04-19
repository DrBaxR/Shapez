using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowParent : MonoBehaviour
{
    public Transform target;
    public float xPos;
    public float yPos;
    public float zPos;

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position - new Vector3(xPos,yPos,zPos), 20f);
    }
}
