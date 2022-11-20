using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageTime : MonoBehaviour
{
    public float time;
    TimerUi timerUI;

    private void Awake()
    {
        timerUI = FindObjectOfType<TimerUi>();
    }

    private void Update()
    {
        time += Time.deltaTime;
        timerUI.UpdateTime(time);
    }
}
