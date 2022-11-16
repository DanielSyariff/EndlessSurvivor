using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void StartGameplay(string sceneName)
    {
        SceneManager.LoadScene("Essential", LoadSceneMode.Single);
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }
}
