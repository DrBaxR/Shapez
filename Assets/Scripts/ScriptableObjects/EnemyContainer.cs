using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "ScriptableObjects/EnemyContainer")]
public class EnemyContainer : ScriptableObject
{
    public List<GameObject> enemies;
}
