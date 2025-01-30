using UnityEngine;

public class JoystickAnimationController : MonoBehaviour
{
    public Animator animator;  // Reference to the Animator component
    public string animationTrigger = "IsMoving";  // The trigger or boolean parameter name in Animator
    public float joystickThreshold = 0.1f;  // Threshold to detect joystick movement

    private void Update()
    {
        // Get the joystick input (for both horizontal and vertical axes)
        float horizontal = Input.GetAxis("Horizontal");  // Get horizontal joystick axis input
        float vertical = Input.GetAxis("Vertical");     // Get vertical joystick axis input
        
        Debug.Log(Mathf.Abs(horizontal) + Mathf.Abs(vertical));

        // Check if joystick is moved beyond the threshold (both positive and negative directions)
        bool isMoving = Mathf.Abs(horizontal) > joystickThreshold || Mathf.Abs(vertical) > joystickThreshold;

        // Set the "IsMoving" boolean parameter in the Animator based on joystick input
        // animator.SetBool(animationTrigger, isMoving);

        // Alternatively, control the animation speed (if you're using animation speed control)
        animator.speed = isMoving ? 1f : 0f;
    }
}