using UnityEngine;
using Unity.Netcode;

public class Movable : NetworkBehaviour
{
    private InitPlayer initPlayer;
    private SoundManager soundManager;
    private Rigidbody rb;
    private int spawnDistance = 30;
    private int max_angular_velocity = 4;
    private bool move_enable = false;
    private int max_speed = 50;
    [SerializeField] private float move_speed = 5;
    [SerializeField] private float rotate_speed = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        soundManager = GetComponentInChildren<SoundManager>();
        initPlayer = GetComponent<InitPlayer>();
        int player_number = initPlayer.getPlayerNumber();
        print("MOVING" + player_number);
        this.transform.position = new Vector3((player_number + 1) * spawnDistance, 0, 0);
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (move_enable) {
            Move();
            Rotate();
            Dampen();
            SelfRight();
        }
    }

    void SelfRight() {
        //if any of the rotation keys are held, return
        if (Input.GetKey(KeyCode.W) || 
            Input.GetKey(KeyCode.A) || 
            Input.GetKey(KeyCode.S) || 
            Input.GetKey(KeyCode.D) || 
            Input.GetKey(KeyCode.E) || 
            Input.GetKey(KeyCode.Q)) {
            return;
        }
        //calculate the angle between the current up vector and the world up vector along roll axis
        Quaternion forwardRotation = Quaternion.LookRotation(transform.forward, Vector3.up);
        float angle = Quaternion.Angle(transform.rotation, forwardRotation);
        //calculate the rotation axis
        Vector3 rotationAxis = Vector3.Cross(transform.up, Vector3.up);
        //apply torque along the rotation axis
        rb.AddTorque(rotationAxis * angle * 0.01f);
    }

    void Dampen() {
        rb.angularVelocity = rb.angularVelocity * 0.99f;
        rb.linearVelocity = rb.linearVelocity * 0.99f;
    }

    void Rotate() {
        if (rb.angularVelocity.magnitude > max_angular_velocity) {
            return;
        }
        //yaw
        if (Input.GetKey(KeyCode.D)) {
            rb.AddTorque(transform.up * rotate_speed);
            //add slight roll
            rb.AddTorque(-transform.forward * rotate_speed * 0.1f);
        }
        if (Input.GetKey(KeyCode.A)) {
            rb.AddTorque(-transform.up * rotate_speed);
            //add slight roll
            rb.AddTorque(transform.forward * rotate_speed * 0.1f);
        }
        //pitch
        if (Input.GetKey(KeyCode.W)) {
            rb.AddTorque(transform.right * rotate_speed);
        }
        if (Input.GetKey(KeyCode.S)) {
            rb.AddTorque(-transform.right * rotate_speed);
        }
        //roll
        if (Input.GetKey(KeyCode.Q)) {
            rb.AddTorque(transform.forward * rotate_speed);
        }
        if (Input.GetKey(KeyCode.E)) {
            rb.AddTorque(-transform.forward * rotate_speed);
        }
    }

    void Move() {
        if (rb.linearVelocity.magnitude > max_speed) {
            return;
        }
        if (Input.GetKey(KeyCode.Space)) {
            rb.AddForce(transform.forward * move_speed);
            soundManager.PlaySound("thruster");
            
        }
        else if (Input.GetKey(KeyCode.LeftShift)) {
            rb.AddForce(-transform.forward * move_speed);
            soundManager.PlaySound("thruster");
        }
        else {
            soundManager.StopSound("thruster");
        }
    }

    public void enableMove() {
        move_enable = true;
    }
}