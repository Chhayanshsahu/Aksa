using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject _object; // Reference to an object to destroy on win
    [SerializeField]
    private Transform[] Images; // Array of transforms to check for rotation
    [SerializeField]
    private GameObject winText; // Reference to the win text GameObject
    [SerializeField]
    private GameObject winPanel; // Reference to the win panel GameObject
    public static bool youWin; // Static flag to track win state

    void Start()
    {
        // Ensure the cursor is visible and unlocked
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Deactivate the win text and panel at the start of the game
        winText.SetActive(false);
        winPanel.SetActive(false);

        // Reset the win state
        youWin = false;
    }

    // Update is called once per frame
    public void Update()
    {
        // Check if all Images' rotations are at 0 (indicating a win condition)
        if (Images[0].rotation.z == 0 &&
            Images[1].rotation.z == 0 &&
            Images[2].rotation.z == 0 &&
            Images[3].rotation.z == 0 &&
            Images[4].rotation.z == 0 &&
            Images[5].rotation.z == 0 &&
            Images[6].rotation.z == 0 &&
            Images[7].rotation.z == 0 &&
            Images[8].rotation.z == 0 &&
            Images[9].rotation.z == 0 &&
            Images[10].rotation.z == 0 &&
            Images[11].rotation.z == 0)
        {
            // Set the win state to true
            youWin = true;

            // Lock the cursor (optional, depending on your game design)
            Cursor.lockState = CursorLockMode.Locked;

            // Start the win sequence coroutine
            StartCoroutine(WinSequence());
        }
    }

    private IEnumerator WinSequence()
    {
        // Wait for 2 seconds before showing the win text and panel
        yield return new WaitForSeconds(2f);

        // Activate the win text and panel GameObjects
        winText.SetActive(true);
        winPanel.SetActive(true);

        // Destroy the specified object (if any)
        if (_object != null)
        {
            Destroy(_object);
        }

        // Wait for 4 seconds before changing the scene
        yield return new WaitForSeconds(4f);

        // Unload the current scene
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);

        // Load the "Envir1" scene
        SceneManager.LoadScene("Envir1", LoadSceneMode.Single);

        // Wait until the new scene is fully loaded
        yield return new WaitUntil(() => SceneManager.GetActiveScene().name == "Envir");

        // Additional logic for the new scene (e.g., restoring player position) can go here
    }
}