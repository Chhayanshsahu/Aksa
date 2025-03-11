using UnityEngine;

public class PlayerEnemyCollisionWithBackgroundAndVictoryMusic : MonoBehaviour
{
    public AudioSource backgroundMusicSource; // AudioSource for background music
    public AudioSource collisionSoundSource;  // AudioSource for collision sound effect
    public AudioSource victoryMusicSource;   // AudioSource for victory music

    public AudioClip backgroundMusic;        // Background music clip
    public AudioClip collisionSound;         // Sound to play when colliding with the enemy
    public AudioClip victoryMusic;           // Sound to play when the player wins

    private bool hasWon = false;             // Track if the player has won

    private void Start()
    {
        // Set up background music
        if (backgroundMusicSource != null && backgroundMusic != null)
        {
            backgroundMusicSource.clip = backgroundMusic;
            backgroundMusicSource.loop = true; // Loop the background music
            backgroundMusicSource.Play();
        }
        else
        {
            Debug.LogWarning("Background music AudioSource or AudioClip is not assigned.");
        }

        // Set up collision sound
        if (collisionSoundSource == null || collisionSound == null)
        {
            Debug.LogWarning("Collision sound AudioSource or AudioClip is not assigned.");
        }

        // Set up victory music
        if (victoryMusicSource == null || victoryMusic == null)
        {
            Debug.LogWarning("Victory music AudioSource or AudioClip is not assigned.");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has an "Enemy" tag
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Play the collision sound if the AudioSource and AudioClip are assigned
            if (collisionSoundSource != null && collisionSound != null)
            {
                collisionSoundSource.PlayOneShot(collisionSound);
            }
            else
            {
                Debug.LogWarning("Collision sound AudioSource or AudioClip is not assigned.");
            }
        }

        // Check if the collided object has a "prince" tag (win condition)
        if (collision.gameObject.CompareTag("prince"))
        {
            WinGame(); // Call the WinGame method to play victory music
        }
    }

    // Call this method when the player wins the game
    public void WinGame()
    {
        if (hasWon) return; // Prevent multiple calls

        hasWon = true;

        // Stop background music
        if (backgroundMusicSource != null)
        {
            backgroundMusicSource.Stop();
        }

        // Play victory music
        if (victoryMusicSource != null && victoryMusic != null)
        {
            victoryMusicSource.clip = victoryMusic;
            victoryMusicSource.loop = false; // Do not loop victory music
            victoryMusicSource.Play();
        }
        else
        {
            Debug.LogWarning("Victory music AudioSource or AudioClip is not assigned.");
        }

        Debug.Log("Player has won the game!");
    }
}