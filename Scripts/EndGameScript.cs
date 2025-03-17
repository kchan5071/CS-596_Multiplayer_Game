using UnityEditor.ProjectWindowCallback;
using UnityEngine;

public class EndGameScript : MonoBehaviour
{
    
    private SoundManager soundManager;
    [SerializeField] GameObject endGameScreen; // Reference to the end game screen UI element
    private CheckpointCounter checkpointCounter; // Reference to the CheckpointCounter script
    private bool ended = false; // Flag to check if the game has ended

    void Start()
    {
        soundManager = GetComponentInChildren<SoundManager>(); // Get the SoundManager component attached to the same GameObject
        checkpointCounter = gameObject.GetComponent<CheckpointCounter>(); // Get the CheckpointCounter component attached to the same GameObject
    }

    // Update is called once per frame
    void Update()
    {
        if (checkpointCounter != null && checkpointCounter.IsFinished() && !ended) // Check if the game is finished and not already ended
        {
            Debug.Log("Game Over!"); // Log the game over message
            ended = true; // Set the ended flag to true
            // endGameScreen.SetActive(true); // Activate the end game screen UI element
            soundManager.PlaySound("game_over"); // Play the game over sound
        }   
    }
}
