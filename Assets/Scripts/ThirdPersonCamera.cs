using System;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [Header("References")] 
    public Transform orientation;
    public Transform player;
    public Transform playerObj;

    public float rotationSpeed;

    private void Update()
    {
        var viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;

        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");
        var inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (inputDir != Vector3.zero)
        {
            playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
        }
    }
}
