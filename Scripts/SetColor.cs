using UnityEngine;
using Unity.Netcode;

public class SetColor : NetworkBehaviour
{    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void setColor(int playerNumber) {
        if (playerNumber == 1) {
            GetComponent<Renderer>().material.color = Color.red;
        } else if (playerNumber == 2) {
            GetComponent<Renderer>().material.color = Color.blue;
        } else if (playerNumber == 3) {
            GetComponent<Renderer>().material.color = Color.green;
        } else if (playerNumber == 4) {
            GetComponent<Renderer>().material.color = Color.yellow;
        } else if (playerNumber == 5) {
            GetComponent<Renderer>().material.color = Color.magenta;
        } else if (playerNumber == 6) {
            GetComponent<Renderer>().material.color = Color.cyan;
        } else if (playerNumber == 7) {
            GetComponent<Renderer>().material.color = Color.black;
        } else if (playerNumber == 8) {
            GetComponent<Renderer>().material.color = Color.white;
        } else if (playerNumber == 9) {
            GetComponent<Renderer>().material.color = Color.grey;
        } else if (playerNumber == 10) {
            GetComponent<Renderer>().material.color = Color.gray;
        } else {
            GetComponent<Renderer>().material.color = Color.white;
        }
    }
}
