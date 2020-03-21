using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position - new Vector3(0, 0, 5), 20f);
    }
}
