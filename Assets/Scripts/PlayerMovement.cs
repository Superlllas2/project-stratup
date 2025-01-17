using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Joystick joystick;
    public float speed = 5.0f;

    private void Update()
    {
        // Get the input from the joystick
        Vector2 inputDirection = joystick.InputDirection;

        // Move the player based on the input
        Vector3 moveDirection = new Vector3(inputDirection.x, 0, inputDirection.y);
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
    }
}