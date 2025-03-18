using UnityEngine;
using UnityEngine.UI;

public class WinCondition : MonoBehaviour
{
    public Text winText; // Reference to the UI Text object
    public GameObject winPanel; // Reference to the UI Panel
    public Image progressImage; // Reference to the image (e.g., progress bar or puzzle)

    [Range(0, 1)]
    public float completionThreshold = 1f; // Threshold for completion (e.g., 1 = 100%)

    void Start()
    {
        // Ensure the text and panel are hidden at the start
        winText.gameObject.SetActive(false);
        winPanel.SetActive(false);
    }

    void Update()
    {
        // Check if the image is complete (e.g., progress bar is full)
        if (IsImageComplete())
        {
            ShowWinScreen();
        }
    }

    bool IsImageComplete()
    {
        // Check if the image's fill amount (or other condition) meets the threshold
        if (progressImage.fillAmount >= completionThreshold)
        {
            return true;
        }
        return false;
    }

    void ShowWinScreen()
    {
        // Enable the panel and text
        winPanel.SetActive(true);
        winText.gameObject.SetActive(true);
    }
}