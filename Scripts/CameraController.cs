using UnityEngine;
using Unity.Netcode;

public class CameraController : NetworkBehaviour
{
    private GameObject camera_object;
    private Camera player_camera;
    private string currentTag = "Untagged";


    void Start()
    {
        currentTag = gameObject.tag;
        foreach (Transform child in transform)
        {
            if (child.tag == "PlayerCam")
            {
                camera_object = child.gameObject;
                player_camera = camera_object.GetComponent<Camera>();
            }
        }
        if (IsLocalPlayer)
        {
            camera_object.SetActive(true);
        }
        else
        {
            camera_object.SetActive(false);
        }
    }

    void LateUpdate() {
        if (IsLocalPlayer)
        {
            Quaternion at_player = Quaternion.LookRotation(transform.position - camera_object.transform.position);
            Vector3 velocity = GetComponent<Rigidbody>().linearVelocity;
            float speed = velocity.magnitude;
            camera_object.transform.position = transform.position - (at_player * (Vector3.forward * 3) * (speed + 3));
            //make camera look at player using slerp
            camera_object.transform.rotation = Quaternion.Slerp(camera_object.transform.rotation, at_player, Time.deltaTime);
        }
    }
}
