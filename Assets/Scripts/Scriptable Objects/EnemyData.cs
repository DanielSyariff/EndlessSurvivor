using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Survivor/Enemy")]
public class EnemyData : ScriptableObject
{
    public string Name;
    public GameObject enemy;
    public EnemyStats stats;
}
