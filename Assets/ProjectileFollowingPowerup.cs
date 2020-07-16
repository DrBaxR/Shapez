using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFollowingPowerup : MonoBehaviour
{
    private Player player;
    private List<Transform> targets;
    public List<GameObject> projetiles;


    [HideInInspector]
    public bool isActive;

    

    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
