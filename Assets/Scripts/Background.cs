using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
   

    private void Awake()
    {
       
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();
        Material mat = mr.material;
        Vector2 offset = mat.mainTextureOffset;
        offset.x = GameObject.FindGameObjectWithTag("Player").transform.position.x / transform.localScale.x * 0.5f;
        offset.y = GameObject.FindGameObjectWithTag("Player").transform.position.y / transform.localScale.y * 0.5f;
        mat.mainTextureOffset = offset;

    }
}
