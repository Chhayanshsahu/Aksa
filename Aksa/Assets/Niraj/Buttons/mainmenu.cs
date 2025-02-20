using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Method to load the game scene
    public void PlayGame()
    {
        // Load the scene with build index 1 asynchronously
        SceneManager.LoadSceneAsync(1);
    }

    // Method to quit the game
    public void QuitGame()
    {
        // Quit the application
        Application.Quit();
    }
}