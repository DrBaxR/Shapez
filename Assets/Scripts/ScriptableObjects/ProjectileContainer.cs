using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "ScriptableObjects/ProjContainer")]
public class ProjectileContainer : ScriptableObject
{
    public List<GameObject> projectiles;
}
