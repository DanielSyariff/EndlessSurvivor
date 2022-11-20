using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerUi : MonoBehaviour
{
    TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateTime(float time)
    {
        int minutes = (int)(time / 60f);
        int seconds = (int)(time % 60f);

        text.text = "Time : " + minutes.ToString() + ":" + seconds.ToString("00");
    }
}
