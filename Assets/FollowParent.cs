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
        transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x + xPos,target.position.y + yPos,target.position.z + zPos), 20f);
    }
}
