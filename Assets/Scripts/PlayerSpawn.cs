using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerSpawn : NetworkBehaviour
{
    [SerializeField] private Vector3 spawnPosition = new Vector3(300, 300, 300); // Default spawn position

    public override void OnNetworkSpawn()
    {
        if (IsOwner) // Only for the local player
        {
            // Set the player's position to the specified spawn position
            transform.position = spawnPosition;
        }
    }

}
