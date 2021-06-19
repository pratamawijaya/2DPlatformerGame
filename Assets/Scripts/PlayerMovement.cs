using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpPower;
    [SerializeField] private LayerMask jumpableGround;

    private Rigidbody2D playerBody;
    private BoxCollider2D boxCollider;
    private SpriteRenderer spriteRenderer;
    private Animator playerAnimator;

    private float horizontalInput;

    // state
    private enum MovementState
    {
        idle, // 0
        running, // 1
        jumping, // 2
        falling // 3
    }

    private MovementState playerState = MovementState.idle;

    private void Awake()
    {
        playerBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        playerAnimator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

       
        UpdateAnimationState();

       
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            playerBody.velocity = new Vector2(playerBody.velocity.x, jumpPower);
        }
    }

    private void UpdateAnimationState()
    {

        
        playerBody.velocity = new Vector2(horizontalInput * movementSpeed, playerBody.velocity.y);


        MovementState state;

        if(horizontalInput > 0f)
        {
            spriteRenderer.flipX = false;
            state = MovementState.running;
        }
        else if(horizontalInput < 0f)
        {
            spriteRenderer.flipX = true;
            state = MovementState.running;
        }
        else
        {
            state = MovementState.idle;
        }

        if (playerBody.velocity.y > .1f)
        {
            state = MovementState.jumping;

        }
        else if(playerBody.velocity.y < -.1f)
        {
            state = MovementState.falling;

        }

        playerAnimator.SetInteger("state",(int) state);
    }

    private void movementRightLeft(float horizontalInput)
    {
       

       
    }

    private bool IsGrounded()
    {
        bool isGrounded = Physics2D.BoxCast(
            boxCollider.bounds.center,
            boxCollider.bounds.size,
            0f, 
            Vector2.down,
            .1f,
            jumpableGround
            );

        LogMe("Is Grounded : " + isGrounded);
        return isGrounded;
    }

    private void LogMe(string message)
    {
        Debug.Log("log : " + message);
    }
}
