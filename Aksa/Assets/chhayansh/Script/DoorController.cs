using UnityEngine;

public class DoorController : MonoBehaviour
{
    public float openAngle = 90f; // Angle to rotate the door when opening
    public float smoothSpeed = 2f; // Speed of the rotation

    private bool isOpen = false;
    private Quaternion initialRotation; // Initial rotation of the door
    private Quaternion targetRotation; // Target rotation when opening/closing

    void Start()
    {
        // Store the initial rotation of the door
        initialRotation = transform.rotation;
        targetRotation = initialRotation;
    }

    void Update()
    {
        // Smoothly rotate the door towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, smoothSpeed * Time.deltaTime);
    }

    public void ToggleDoor()
    {
        // Toggle the door's open/close state
        isOpen = !isOpen;

        // Calculate the target rotation based on the door's state
        if (isOpen)
        {
            // Rotate the door around its Y-axis to open it
            targetRotation = initialRotation * Quaternion.Euler(0, openAngle, 0);
        }
        else
        {
            // Reset the rotation to the initial state to close it
            targetRotation = initialRotation;
        }
    }
}