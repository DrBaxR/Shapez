using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixRotation : MonoBehaviour
{
    public float whatPosX;
    public float whatPosY;

    private Transform player;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void Update()
    {
        this.transform.position = new Vector3(player.position.x + whatPosX,player.position.y + whatPosY,player.position.z);
    }

    void LateUpdate()
    {
        
    }
}
