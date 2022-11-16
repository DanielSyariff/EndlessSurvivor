using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public void ApplicationQuit()
    {
        Debug.Log("APPLICATION QUIT");
        Application.Quit();
    }
}
