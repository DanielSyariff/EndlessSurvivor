using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExperienceBar : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] TextMeshProUGUI levelText;

    // Update is called once per frame
    public void UpdateExperienceSlider(int current, int target)
    {
        slider.maxValue = target;
        slider.value = current;
    }

    public void SetLevelText(int level)
    {
        levelText.text = "LEVEL : " + level.ToString();
    }
}
