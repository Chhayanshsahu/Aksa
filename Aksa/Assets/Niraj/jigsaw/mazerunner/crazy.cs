using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class crazy : MonoBehaviour
{
    public int keys = 0;
    public float speed = 3.0f;
    public Text keyAmount;
    public Text youwin; // Ensure this is assigned in the Inspector
    public GameObject gate;
    public Text displayText; // Reference to the Text object
    public float displayTime = 2f; // Time to display the text

    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        youwin.gameObject.SetActive(false); // Hide the "You Win!!!" text at the start
        rb2d = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.linearVelocity = movement * speed;

        if (keys == 3)
        {
            Destroy(gate);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Handle collision with objects tagged "keys"
        if (collision.gameObject.CompareTag("keys"))
        {
            keys++;
            keyAmount.text = "keys: " + keys;
            Destroy(collision.gameObject);
        }

        // Handle collision with objects tagged "enemy"
        if (collision.gameObject.CompareTag("enemy"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        // Handle collision with objects tagged "okk"
        if (collision.gameObject.CompareTag("okk"))
        {
            // Reverse the movement direction when colliding with an object tagged "okk"
            rb2d.linearVelocity = -rb2d.linearVelocity;
        }

        // Handle collision with objects tagged "prince"
        if (collision.gameObject.CompareTag("prince"))
        {
            youwin.text = "You Win!!!"; // Set the text
            youwin.gameObject.SetActive(true); // Make the text visible
        }

        // Check if the collided object has the tag "key"
        if (collision.gameObject.CompareTag("keys"))
        {
            // Show the text
            if (displayText != null)
            {
                displayText.gameObject.SetActive(true);
                Invoke("HideText", displayTime); // Hide the text after a delay
            }

            // Optionally, destroy the key object
            Destroy(collision.gameObject);
        }
    }

    private void HideText()
    {
        if (displayText != null)
        {
            displayText.gameObject.SetActive(false);
        }
    }
}