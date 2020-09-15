﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]
    private float _jumpForce = 5;
    private bool _resetJump = false;
    [SerializeField]
    private float _speed = 3;
    PlayerAnimation playerAnimation;
    SpriteRenderer sprite;
    private bool _isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<PlayerAnimation>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        if(Input.GetMouseButtonDown(0) && _isGrounded)
        {
            playerAnimation.Attack();
        }
    }
    void Movement()
    {
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        _isGrounded = isGrounded();
        if (horizontalInput > 0)
            Flip(false);
        else if (horizontalInput < 0)
            Flip(true);



        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            playerAnimation.Jump(true);
            rb.velocity = new Vector2(rb.velocity.x, _jumpForce);
            StartCoroutine(ResetJump());
        }

        rb.velocity = new Vector2(horizontalInput * _speed, rb.velocity.y);
        playerAnimation.Move(horizontalInput);
    }

    void Flip(bool flipRight)
    {
        if (flipRight)
            sprite.flipX = true;
        else
            sprite.flipX = false;
    }

    private bool isGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 0.8f, 1 << 8);
        Debug.DrawRay(transform.position, Vector3.down, Color.green);
        if (hitInfo.collider != null)
        {
            if (_resetJump == false)
            {
                playerAnimation.Jump(false);
                return true;
            }

        }
        return false;
    }



    IEnumerator ResetJump()
    {
        _resetJump = true;
        yield return new WaitForSeconds(0.1f);
        _resetJump = false;
    }

}

