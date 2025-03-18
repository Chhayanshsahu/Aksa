using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAndDrop : MonoBehaviour
{
    public Camera playerCamera; // Reference to the player's camera
    public float maxPickupDistance = 5f; // Maximum distance to pick up an item
    public Vector3[] holdPositions; // Array of positions relative to the player to hold items
    public KeyCode pickupKey = KeyCode.P; // Key to pick up an item
    public KeyCode dropKey = KeyCode.O; // Key to drop an item

    private GameObject itemCurrentlyHolding; // The item currently being held
    private bool isHolding = false; // Whether the player is currently holding an item
    private int currentHoldPositionIndex = 0; // Index of the current hold position

    void Update()
    {
        if (Input.GetKeyDown(pickupKey)) Pickup();
        if (Input.GetKeyDown(dropKey)) Drop();
    }

    void Pickup()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, maxPickupDistance))
        {
            if (hit.transform.CompareTag("Item"))
            {
                if (isHolding) Drop(); // Drop the current item if holding one

                itemCurrentlyHolding = hit.transform.gameObject;
                SetItemPhysics(false); // Disable physics on the item

                // Set the item's parent to the player and adjust its position
                itemCurrentlyHolding.transform.parent = transform;
                itemCurrentlyHolding.transform.localPosition = holdPositions[currentHoldPositionIndex] ;
                itemCurrentlyHolding.transform.localEulerAngles = Vector3.zero;

                isHolding = true;
                currentHoldPositionIndex = (currentHoldPositionIndex + 1) % holdPositions.Length; // Cycle through hold positions
            }
        }
    }

    void Drop()
    {
        if (itemCurrentlyHolding != null)
        {
            itemCurrentlyHolding.transform.parent = null;
            SetItemPhysics(true); // Enable physics on the item

            // Position the item on the ground in front of the player
            RaycastHit hitDown;
            if (Physics.Raycast(transform.position, -Vector3.up, out hitDown))
            {
                itemCurrentlyHolding.transform.position = hitDown.point + new Vector3(transform.forward.x, 0, transform.forward.z);
            }

            isHolding = false;
        }
    }

    void SetItemPhysics(bool enablePhysics)
    {
        foreach (var collider in itemCurrentlyHolding.GetComponentsInChildren<Collider>())
        {
            if (collider != null) collider.enabled = enablePhysics;
        }

        foreach (var rigidbody in itemCurrentlyHolding.GetComponentsInChildren<Rigidbody>())
        {
            if (rigidbody != null) rigidbody.isKinematic = !enablePhysics;
        }
    }
}