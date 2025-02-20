using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    // Method to pause the game
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f; // Freeze the game
    }

    // Method to return to the main menu
    public void Home()
    {
        Time.timeScale = 1f; // Ensure the game is not paused
        SceneManager.LoadScene("Main Menu");
    }

    // Method to resume the game
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f; // Unfreeze the game
    }

    // Method to restart the current level
    public void Restart()
    {
        Time.timeScale = 1f; // Ensure the game is not paused
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}