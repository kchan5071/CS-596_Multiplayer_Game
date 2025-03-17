using UnityEngine;

public class FinishLine : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log("Finish line crossed by player: " + other.gameObject.name); // Log the name of the player that crossed the finish line
        other.gameObject.GetComponent<CheckpointCounter>().PassFinishLine(); // Call the PassFinishLine method on the CheckpointCounter script
    }
}
