using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Canon : MonoBehaviour
{
    [SerializeField] private Transform canonTransform; // Ensure this is assigned in the Inspector
    [SerializeField] private float canonSpeed = 100f; // Speed for rotation
    private PlayerInput playerInput;
    private InputAction mouse;

    // Start is called before the first frame update
    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        mouse = playerInput.actions["Mouse"];
    }

    // Update is called once per frame
    void Update()
    {
        rotateCanon();
    }

    void rotateCanon()
    {
    Vector2 mousePosition = mouse.ReadValue<Vector2>();
    Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.nearClipPlane));
    Vector2 direction = new Vector2(mouseWorldPosition.x - canonTransform.position.x, mouseWorldPosition.y - canonTransform.position.y);
    float canonAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

    canonTransform.localRotation = Quaternion.Euler(0, 0, canonAngle);
    }
}
