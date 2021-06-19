using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpPower;

    private Rigidbody2D playerBody;
    private BoxCollider2D boxCollider;
    private Animator playerAnimator;

    private float horizontalInput;

    private void Awake()
    {
        playerBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        playerAnimator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        movementRightLeft(horizontalInput);

        playerAnimator.SetBool("isRun", horizontalInput != 0);

        if (Input.GetKey(KeyCode.Space))
        {
            playerBody.velocity = new Vector2(playerBody.velocity.x, jumpPower); 
        }
    }

    private void movementRightLeft(float horizontalInput)
    {
        playerBody.velocity = new Vector2(horizontalInput * movementSpeed, playerBody.velocity.y);

        if (horizontalInput > 0.01f)
        {
            // tengok kanan
            transform.localScale = Vector3.one;
        }
        else if (horizontalInput < -0.01f)
        {
            // tengok kiri
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
