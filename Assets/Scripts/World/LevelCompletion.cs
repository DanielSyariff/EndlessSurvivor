using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompletion : MonoBehaviour
{
    [SerializeField] float timeToCompleteLevel;

    StageTime stageTime;
    PauseManager pauseManager;

    [SerializeField] GameWinPanel levelCompletePanel;

    private void Awake()
    {
        stageTime = GetComponent<StageTime>();
        pauseManager = FindObjectOfType<PauseManager>();
        levelCompletePanel = FindObjectOfType<GameWinPanel>(true);
    }

    private void Update()
    {
        if (stageTime.time > timeToCompleteLevel)
        {
            levelCompletePanel.gameObject.SetActive(true);
            pauseManager.PauseGame();
        }
    }
}
