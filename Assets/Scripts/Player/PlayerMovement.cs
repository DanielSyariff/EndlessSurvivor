using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Scripts")]
    public MovementJoystick movementJoystick;
    public bool useJoystick;
    public SpriteAnimate animate;
    public Character character;

    Rigidbody2D rb;
    [HideInInspector] public Vector3 movementVector;
    public float lastHorizontalVector;
    public float lastVerticalVector;

    private void Awake()
    {
        character = GetComponent<Character>();
        rb = GetComponent<Rigidbody2D>();
        movementVector = new Vector3();
        animate = GetComponent<SpriteAnimate>();
    }

    private void Start()
    {
        lastHorizontalVector = -1f;
        lastVerticalVector = -1f;
    }

    private void Update()
    {
        if (!useJoystick)
        {
            //Keyboard
            movementVector.x = Input.GetAxis("Horizontal");
            movementVector.y = Input.GetAxis("Vertical");

            if (movementVector.x != 0)
            {
                lastHorizontalVector = movementVector.x;
            }
            if (movementVector.y != 0)
            {
                lastVerticalVector = movementVector.y;
            }

            animate.horizontal = movementVector.x;
            animate.vertical = movementVector.y;

            rb.velocity = movementVector *= character.speed;
        }
        else
        {
            //Joystick Movement
            if (movementJoystick.joystickVec.x != 0)
            {
                lastHorizontalVector = movementJoystick.joystickVec.x;
            }
            if (movementJoystick.joystickVec.y != 0)
            {
                lastVerticalVector = movementJoystick.joystickVec.y;
            }

            animate.horizontal = movementJoystick.joystickVec.x;
            animate.vertical = movementJoystick.joystickVec.y;

            rb.velocity = new Vector2(movementJoystick.joystickVec.x * character.speed, movementJoystick.joystickVec.y * character.speed);
        }
    }
}
