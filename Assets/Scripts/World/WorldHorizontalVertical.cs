using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldHorizontalVertical : MonoBehaviour
{
    [SerializeField] Transform bg1;
    [SerializeField] Transform bg2;
    [SerializeField] Camera cam;

    [SerializeField] float size;

    private Vector3 bg1TargetPos = new Vector3();
    private Vector3 bg2TargetPos = new Vector3();
    // Start is called before the first frame update
    void Start()
    {
        cam = FindObjectOfType<Camera>();

        BoxCollider2D bgCollider1 = bg1.GetComponent<BoxCollider2D>();
        BoxCollider2D bgCollider2 = bg2.GetComponent<BoxCollider2D>();

        size = bgCollider1.size.y;

        bgCollider1.enabled = false;
        bgCollider2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        switch (GameManager.instance.worldManager.gameplayMode)
        {
            case GameplayMode.Horizontal:
                //World
                if (cam.transform.position.x - 10 >= bg2.position.x)
                {
                    bg1.position = GameManager.instance.SetPos(bg1TargetPos, bg1.position.x + size, bg2.position.y, bg1.position.z);
                    SwitchBG();
                }

                if (cam.transform.position.x - 10 < bg1.position.x)
                {
                    bg2.position = GameManager.instance.SetPos(bg2TargetPos, bg2.position.x - size, bg1.position.y, bg2.position.z);
                    SwitchBG();
                }
                break;
            case GameplayMode.Vertical:
                //World
                if (cam.transform.position.y - 10 >= bg2.position.y)
                {
                    bg1.position = GameManager.instance.SetPos(bg1TargetPos, bg1.position.x, bg2.position.y + size, bg1.position.z);
                    SwitchBG();
                }

                if (cam.transform.position.y - 10 < bg1.position.y)
                {
                    bg2.position = GameManager.instance.SetPos(bg2TargetPos, bg2.position.x, bg1.position.y - size, bg2.position.z);
                    SwitchBG();
                }
                break;
        }
    }

    public void SwitchBG()
    {
        Transform temp = bg1;
        bg1 = bg2;
        bg2 = temp;
    }
}
