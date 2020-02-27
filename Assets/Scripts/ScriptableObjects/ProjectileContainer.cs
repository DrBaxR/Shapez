using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "ProjContainer")]
public class ProjectileContainer : ScriptableObject
{
    public List<GameObject> projectiles;
}
