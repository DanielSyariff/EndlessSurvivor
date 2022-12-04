using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Transform playerTransform;
    public WorldManager worldManager;

    private void Start()
    {
        worldManager = FindObjectOfType<WorldManager>();
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public Vector3 SetPos(Vector3 pos, float x, float y, float z)
    {
        pos.x = x;
        pos.y = y;
        pos.z = z;
        return pos;
    }
}
