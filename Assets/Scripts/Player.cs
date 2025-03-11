using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CharacterController2D))]
[RequireComponent(typeof(PlayerInput))]
public class Player : MonoBehaviour
{
    
    private PlayerInput _playerInput;
    private CharacterController2D _controller;
    private Vector2 _movementInput;


    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _controller = GetComponent<CharacterController2D>();
        _playerInput.OnJumpPressed += OnJump;
        _playerInput.OnAttackPressed += OnAttack;
    }

    private void OnAttack()
    {
        throw new NotImplementedException();
    }

    private void OnJump()
    {
        _controller.Jump();
    }
    private void Update()
    {
        _movementInput = _playerInput.MovementInput;
        _controller.SetMovement(_movementInput);
    }
}

