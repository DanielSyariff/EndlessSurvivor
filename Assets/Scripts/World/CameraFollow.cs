using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Camera cam;

    private Vector3 cameratargetPos = new Vector3();

    private void Start()
    {
        target = GameManager.instance.playerTransform;
        cam = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = new Vector3();

        switch (GameManager.instance.worldManager.gameplayMode)
        {
            case GameplayMode.OpenWorld:
                targetPos = GameManager.instance.SetPos(cameratargetPos, target.position.x, target.position.y, cam.transform.position.z);
                break;
            case GameplayMode.Horizontal:
                targetPos = GameManager.instance.SetPos(cameratargetPos, target.position.x, cam.transform.position.y, cam.transform.position.z);
                break;
            case GameplayMode.Vertical:
                targetPos = GameManager.instance.SetPos(cameratargetPos, cam.transform.position.x, target.position.y, cam.transform.position.z);
                break;
            case GameplayMode.Square:
                targetPos = GameManager.instance.SetPos(cameratargetPos, cam.transform.position.x, cam.transform.position.y, cam.transform.position.z);
                break;
        }
        cam.transform.position = Vector3.Lerp(cam.transform.position, targetPos, 0.2f);
    }

    
}
