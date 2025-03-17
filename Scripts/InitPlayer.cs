using UnityEngine;
using Unity.Netcode;

public class InitPlayer : NetworkBehaviour
{
        private SoundManager soundManager;
        public PlayerCounter playerCounter;
        private Movable movable;
        private SetColor setColor;
        private int playerNumber;

        public override void OnNetworkSpawn()
        {
            if (IsOwner)
            {
                soundManager = GetComponentInChildren<SoundManager>(); // Get the SoundManager component attached to the same GameObject
                soundManager.PlaySound("connected");
            }
        }

        void Awake()
        {
            playerCounter = GameObject.FindGameObjectsWithTag("PlayerManager")[0].GetComponent<PlayerCounter>();
            setColor = GetComponent<SetColor>();
            playerCounter.incrementPlayerCount();
            playerNumber = playerCounter.getPlayerCount();
            setColor.setColor(playerNumber);

        }

        void Update()
        {
            if (playerCounter.getPlayerCount() >= 1)
            {
                movable = GetComponent<Movable>();
                movable.enableMove();
            }
        }

        public int getPlayerNumber()
        {
            return playerNumber;
        }


}
