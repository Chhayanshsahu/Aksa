using UnityEngine;

[RequireComponent(typeof(Light))]
public class FlickeringLight : MonoBehaviour
{
    private Light lightToFlicker;
    [SerializeField, Range(0f, 10f)] private float minIntensity = 0.0f; // Increased range
    [SerializeField, Range(0f, 10f)] private float maxIntensity = 10.0f; // Increased range
    [SerializeField, Min(0f)] private float timeBetweenIntensity = 0.05f; // Reduced time for faster flickering
    [SerializeField, Min(1)] private int flickerCount = 2; // Number of times to flicker in a loop
    [SerializeField] private float delayBetweenLoops = 2f; // Delay between flicker loops
    [SerializeField, Range(1f, 5f)] private float intensityMultiplier = 1f; // Multiplier for intensity

    private float currentTimer;
    private int currentFlickerCount = 0; // Counter for flickers
    private bool isFlickering = true; // Flag to control flickering state

    // Event function
    private void Awake()
    {
        lightToFlicker = GetComponent<Light>();
        if (lightToFlicker == null)
        {
            Debug.LogError("No Light component found on this GameObject.");
        }
        ValidateIntensityBounds();
    }

    // Event function
    private void Update()
    {
        if (!isFlickering) return; // Exit if not in flickering state

        currentTimer += Time.deltaTime;

        if (currentTimer >= timeBetweenIntensity)
        {
            // Flicker the light with intensity multiplier
            lightToFlicker.intensity = Random.Range(minIntensity, maxIntensity) * intensityMultiplier;
            currentTimer = 0f; // Reset the timer
            currentFlickerCount++; // Increment flicker count

            // Check if flicker count has reached the desired number
            if (currentFlickerCount >= flickerCount)
            {
                isFlickering = false; // Stop flickering
                Invoke("ResetFlickerLoop", delayBetweenLoops); // Reset after a delay
            }
        }
    }

    private void ResetFlickerLoop()
    {
        currentFlickerCount = 0; // Reset flicker count
        isFlickering = true; // Restart flickering
    }

    private void ValidateIntensityBounds()
    {
        if (minIntensity > maxIntensity)
        {
            Debug.LogWarning("Min Intensity is greater than max Intensity, Swapping values!");
            (minIntensity, maxIntensity) = (maxIntensity, minIntensity);
        }
    }

    // Method to dynamically increase intensity
    public void IncreaseIntensity(float amount)
    {
        minIntensity += amount;
        maxIntensity += amount;

        // Ensure the intensity values stay within a valid range
        minIntensity = Mathf.Clamp(minIntensity, 0f, 10f);
        maxIntensity = Mathf.Clamp(maxIntensity, 0f, 10f);

        // Validate the bounds again
        ValidateIntensityBounds();
    }

    // Method to set intensity multiplier
    public void SetIntensityMultiplier(float multiplier)
    {
        intensityMultiplier = Mathf.Clamp(multiplier, 1f, 5f); // Clamp to a reasonable range
    }
}