using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using System;
using UnityEngine.InputSystem;

public class Player : Movable
{

    private PlayerInputActions input;
    private Vector2 moveInput;

    private void Awake()
    {
        Debug.Log("Awake called");
        input = new PlayerInputActions();
        input.Enable();


        input.Player.Jump.performed += _ => Jump();
        input.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        input.Player.Move.canceled  += ctx => moveInput = Vector2.zero;
    }

    private void Jump()
    {
        print("HELLO");
        fallSpeed = -1f;
    }

    private void Move()
    {

    }

    private void Update()
    {
        Vector3 lDirection = new Vector3(moveInput.x, 0, moveInput.y);
        transform.Translate(lDirection * Time.deltaTime * 5f);

        transform.position -= new Vector3(0, gravity * fallSpeed, 0);
        fallSpeed += 0.01f;
    }
}
