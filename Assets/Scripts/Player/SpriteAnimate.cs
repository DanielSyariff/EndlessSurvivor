using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimate : MonoBehaviour
{
    Animator animator;
    public float horizontal;
    public float vertical;

    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }


    private void Update()
    {
        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);
    }
}
