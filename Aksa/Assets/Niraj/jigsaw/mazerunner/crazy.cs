using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class crazy : MonoBehaviour
{
    public int keys = 0;
    public float speed = 5.0f;
    public Text keyAmount;
    public Text youwin; // Ensure this is assigned in the Inspector
    public GameObject gate;
    public Text displayText; // Reference to the Text object
    public float displayTime = 2f; // Time to display the text

    // Start is called before the first frame update
    void Start()
    {
        youwin.gameObject.SetActive(false); // Hide the "You Win!!!" text at the start
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
        }
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
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(speed * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(-speed * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(0, -speed * Time.deltaTime, 0);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(0, speed * Time.deltaTime, 0);
            }
        }

        // Handle collision with objects tagged "prince"
        if (collision.gameObject.CompareTag("prince"))
        {
            youwin.text = "You Win!!!"; // Set the text
            youwin.gameObject.SetActive(true); // Make the text visible
        }
        {
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
    } // End of OnCollisionEnter2D
    private void HideText()
    {
        if (displayText != null)
        {
            displayText.gameObject.SetActive(false);
        }
    }
} // End of crazy class