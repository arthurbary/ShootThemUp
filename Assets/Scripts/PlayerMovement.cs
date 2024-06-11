using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputAction move;
    [SerializeField]private float speed = 2f;
    private CharacterController characterController;
    public Camera mainCamera ;
    int screenWidth = Screen.width;
    int screenHeight = Screen.height;
    Vector3 playerScreenPosition ;

    
    void Awake() 
    {
        playerInput = GetComponent<PlayerInput>();
        move = playerInput.actions["Move"];
        mainCamera = Camera.main;
    }
    public void OnEnable() 
    {
        move.Enable();
    }
    public void OnDisable() 
    {
        move.Disable();
    }

    void Update() 
    {
        Vector2 movement = move.ReadValue<Vector2>();
        movement *= Time.deltaTime * speed;
        gameObject.transform.Translate(movement);
        playerScreenPosition  = mainCamera.WorldToScreenPoint(transform.position);
        playerScreenPosition.x = Mathf.Clamp(playerScreenPosition.x, 0, Screen.width);
        playerScreenPosition.y = Mathf.Clamp(playerScreenPosition.y, 10, Screen.height);
        transform.position = mainCamera.ScreenToWorldPoint(playerScreenPosition);
    }
}
