using UnityEngine;

public class DoorIntrection : MonoBehaviour
{
   
    public float interactionDistance = 3f; // Distance within which the player can interact with the door
    public KeyCode interactionKey = KeyCode.E; // Key to press to interact with the door
    public LayerMask doorLayer; // Layer mask to filter out only doors

    private DoorController doorController;
    private bool isDoorInRange = false;

    void Update()
    {
        RaycastHit hit;

        // Cast a ray forward from the camera
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactionDistance, doorLayer))
        {
            // Check if the ray hits a door
            if (hit.collider.CompareTag("Door"))
            {
                isDoorInRange = true;
                doorController = hit.collider.GetComponent<DoorController>();

                // Check if the interaction key is pressed
                if (Input.GetKeyDown(interactionKey))
                {
                    // Toggle the door's open/close state
                    doorController.ToggleDoor();
                }
            }
        }
        else
        {
            isDoorInRange = false;
        }
    }

    void OnGUI()
    {
        if (isDoorInRange)
        {
            // Display a prompt to interact with the door
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 100, 50), "Press E to open/close door");
        }
    }
}

