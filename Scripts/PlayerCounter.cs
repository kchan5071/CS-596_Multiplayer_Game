using UnityEngine;
using Unity.Netcode;

public class PlayerCounter : NetworkBehaviour
{
    public int playerCount = 0;

    public void incrementPlayerCount()
    {
        playerCount++;
    }

    public void decrementPlayerCount()
    {
        playerCount--;
    }

    public int getPlayerCount()
    {
        return playerCount;
    }

    void Update()
    {
        if (playerCount == 1) {
            // print("TEST");
        }
        
    }
}
