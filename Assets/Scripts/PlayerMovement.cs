using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    public Joystick joystick;
    public Transform orientation;
    public Transform playerObj;
    public Animator animator;
    
    public float speed = 5.0f; // Player movement speed
    public float rotationSpeed = 10.0f; // Player rotation speed

    private void Update()
    {
        var inputDirection = joystick.InputDirection;

        // Calculate movement direction relative to camera orientation
        var moveDirection = orientation.forward * inputDirection.y + orientation.right * inputDirection.x;

        // If there is some input (not just idle)
        if (moveDirection != Vector3.zero)
        {
            // Move the player in the calculated direction
            transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);

            // Rotate the player to face the direction of movement
            playerObj.forward = Vector3.Slerp(playerObj.forward, moveDirection.normalized, Time.deltaTime * rotationSpeed);

            animator.speed = 1;
        } else
        {
            // Set animation to idle when no movement
            animator.speed = 0;
        }
    }
}