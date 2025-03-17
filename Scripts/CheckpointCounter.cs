using UnityEngine;

public class CheckpointCounter : MonoBehaviour
{

    private SoundManager soundManager;

    private int checkpointsPassed = 0;
    private int checkpointsTotal = 0; // Total number of checkpoints in the game
    private bool isFinished = false; 
    void Start()
    {
        soundManager = GetComponentInChildren<SoundManager>();
        checkpointsPassed = 0;
        checkpointsTotal = GameObject.FindGameObjectsWithTag("Checkpoint").Length; // Find all checkpoints in the scene
    }

    
    // This method is called when the player passes a checkpoint
    public void PassCheckpoint()
    {
        checkpointsPassed++; // Increment the checkpoint counter
        soundManager.PlaySound("checkpoint"); // Play the checkpoint sound
    }

    // This method returns the number of checkpoints passed
    public int GetCheckpointsPassed()
    {
        return checkpointsPassed; // Return the number of checkpoints passed
    }

    public bool AllCheckpointsPassed()
    {
        return checkpointsPassed >= checkpointsTotal; // Check if all checkpoints have been passed
    }

    public void PassFinishLine()
    {
        if (AllCheckpointsPassed())
        {
            isFinished = true; // Set the isFinished flag to true if all checkpoints have been passed
        }
    }

    public bool IsFinished()
    {
        return isFinished; // Return the isFinished flag
    }
}
