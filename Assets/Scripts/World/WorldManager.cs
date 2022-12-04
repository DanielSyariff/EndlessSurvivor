using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameplayMode
{
    OpenWorld,
    Horizontal,
    Vertical,
    Square
}

public class WorldManager : MonoBehaviour
{
    [SerializeField] WorldScrolling worldScrolling;
    [SerializeField] WorldHorizontalVertical worldHorizontalVertical;
    public GameplayMode gameplayMode;
    // Start is called before the first frame update
    void Start()
    {
        switch (gameplayMode)
        {
            case GameplayMode.OpenWorld:
                worldScrolling.enabled = true;
                worldHorizontalVertical.enabled = false;
                break;
            case GameplayMode.Horizontal:
                worldScrolling.enabled = false;
                worldHorizontalVertical.enabled = true;
                break;
            case GameplayMode.Vertical:
                worldScrolling.enabled = false;
                worldHorizontalVertical.enabled = true;
                break;
            case GameplayMode.Square:
                worldScrolling.enabled = false;
                worldHorizontalVertical.enabled = false;
                break;
        }
    }
}
