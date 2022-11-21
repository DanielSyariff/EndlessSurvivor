using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageEventManager : MonoBehaviour
{
    [SerializeField] StageData stageData;
    [SerializeField] EnemiesManager enemiesManager;

    StageTime stageTime;
    int eventIndexer;

    private void Awake()
    {
        stageTime = GetComponent<StageTime>();
    }

    private void Update()
    {
        //Jika Event sudah Max
        if (eventIndexer >= stageData.stageEvents.Count)
        {
            return;
        }

        //Jika event masih berlanjut
        if (stageTime.time > stageData.stageEvents[eventIndexer].time)
        {
            Debug.Log(stageData.stageEvents[eventIndexer].message);

            for (int i = 0; i < stageData.stageEvents[eventIndexer].count; i++)
            {
                enemiesManager.SpawnEnemy(stageData.stageEvents[eventIndexer].enemyToSpawn);
            }

            eventIndexer++;
        }
    }
}
