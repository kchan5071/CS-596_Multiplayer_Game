using UnityEngine;

public class CheckpointEnter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log("Checkpoint entered by player: " + other.gameObject.name); // Log the name of the player that entered the checkpoint
        other.gameObject.GetComponent<CheckpointCounter>().PassCheckpoint(); // Call the PassCheckpoint method on the CheckpointCounter script

    }
}
