using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerInput : MonoBehaviour
{
    public static PlayerInput Instance { get; private set; }    
    public Vector2 MovementInput { get; private set; }
    public event Action OnJumpPressed;
    public event Action OnAttackPressed;

    private PlayerActionMap _playerActionMap;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
        _playerActionMap = new PlayerActionMap();
        _playerActionMap.Enable();
    }
    private void OnDisable()
    {
        _playerActionMap.Disable();
        _playerActionMap.Player.Movement.performed -= OnMovement;
        _playerActionMap.Player.Jump.started -= OnJump;
        _playerActionMap.Player.Attack.started -= OnAttack;
    }
    private void Start()
    {
        _playerActionMap.Player.Movement.performed += OnMovement;
        _playerActionMap.Player.Jump.started += OnJump;
        _playerActionMap.Player.Attack.started +=OnAttack;
        _playerActionMap.Player.Movement.canceled+= cxt => MovementInput = Vector2.zero;
    }

    private void OnAttack(InputAction.CallbackContext context)
    {
        OnAttackPressed?.Invoke();
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        OnJumpPressed?.Invoke();
    }

    private void OnMovement(InputAction.CallbackContext context)
    {
        MovementInput = context.ReadValue<Vector2>();
        Debug.Log(MovementInput);
    }
}
