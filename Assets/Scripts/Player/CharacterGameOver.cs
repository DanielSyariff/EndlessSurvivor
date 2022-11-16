using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGameOver : MonoBehaviour
{
    public GameObject gameOverPanel;
    [SerializeField] GameObject weaponsParent;
    public void GameOver()
    {
        Debug.Log("Game Over");
        GetComponent<PlayerMovement>().enabled = false;
        weaponsParent.SetActive(false);
        gameOverPanel.SetActive(true);
    }
}
