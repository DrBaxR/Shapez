using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "ScriptableObjects/Weapon")]
public class Weapon : ScriptableObject
{
    public float cooldown;
    public GameObject projectile;
    public Sprite sprite;
   

    public void Shoot(Transform currentPos)
    {
        Instantiate(projectile, currentPos.position, currentPos.rotation);
    }


    
    



}
