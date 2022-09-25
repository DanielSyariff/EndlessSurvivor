using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Scripts")]
    public SpriteAnimate animate;

    Rigidbody2D rb;
    Vector3 movementVector;

    [SerializeField] float speed = 3f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        movementVector = new Vector3();
        animate = GetComponent<SpriteAnimate>();
    }

    private void Update()
    {
        movementVector.x = Input.GetAxis("Horizontal");
        movementVector.y = Input.GetAxis("Vertical");

        animate.horizontal = movementVector.x;
        animate.vertical = movementVector.y;

        rb.velocity = movementVector *= speed;
    }
}
