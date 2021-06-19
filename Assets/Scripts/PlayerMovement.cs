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

    private float horizontalInput;

    private void Awake()
    {
        playerBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
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
