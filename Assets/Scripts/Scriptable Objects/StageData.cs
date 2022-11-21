using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class StageEvent
{
    public float time;
    public string message;
    public EnemyData enemyToSpawn;
    public int count;
}


[CreateAssetMenu(fileName = "Stages", menuName = "Survivor/Stage")]
public class StageData : ScriptableObject
{
    public List<StageEvent> stageEvents;
}
