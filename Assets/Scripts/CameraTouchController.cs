using UnityEngine;
using Unity.Cinemachine;
using UnityEngine.EventSystems;

public class CameraTouchController : MonoBehaviour
{
    public CinemachineFreeLook freeLookCamera; // Reference to Cinemachine camera
    private Vector2 lastTouchPosition;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                // Check if the touch is within the screen
                if (touch.phase == TouchPhase.Began)
                {
                    lastTouchPosition = touch.position;
                }
                else if (touch.phase == TouchPhase.Moved)
                {
                    Vector2 delta = touch.position - lastTouchPosition;
                    lastTouchPosition = touch.position;
                    
                    // Adjust Cinemachine camera's axes
                    if (freeLookCamera)
                    {
                        freeLookCamera.m_XAxis.Value += delta.x * 0.1f; // Adjust sensitivity as needed
                        freeLookCamera.m_YAxis.Value -= delta.y * 0.1f;
                    }
                }
            }
        }
    }
}