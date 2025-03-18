using UnityEngine;
using TMPro; // For TextMeshPro

public class ButtonClickHandler : MonoBehaviour
{
    // Reference to the Panel and TextMeshPro UI elements
    public GameObject panel; // The panel to show/hide
    public TextMeshProUGUI displayText; // The TextMeshPro text to update

    // This method is called when the button is clicked
    public void OnButtonClick()
    {
        // Enable the panel
        panel.SetActive(true);

        // Update the TextMeshPro text with controls and color explanations
        displayText.text =
            "Controls:\n" +
            "W Key: Move Forward\n" +
            "A Key: Move Left\n" +
            "S Key: Move Backward\n" +
            "D Key: Move Right\n" +
            "Spacebar: Jump\n\n" +

            "Color Meanings:\n" +
            "Green Color: The green color represents healing after solving clues in the form of a game.\n" +
            "Yellow Color: The yellow color symbolizes moving forward and upward.";
    }
}