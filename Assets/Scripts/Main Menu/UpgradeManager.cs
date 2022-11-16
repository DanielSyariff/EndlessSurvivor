using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] GameObject panel;
    public PauseManager pauseManager;
    private void Awake()
    {
        pauseManager = GetComponent<PauseManager>();
    }

    public void OpenUpgradePanel()
    {
        pauseManager.PauseGame();
        panel.SetActive(true);
    }
    public void CloseUpgradePanel()
    {
        pauseManager.UnPauseGame();
        panel.SetActive(false);
    }
}
