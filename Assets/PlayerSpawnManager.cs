using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawnManager : MonoBehaviour
{
    public Transform[] spawnLocations;
    public GameObject AI;
    private GameObject child;

    void OnPlayerJoined(PlayerInput playerInput)
    {

        Debug.Log("PlayerInput ID: " + playerInput.playerIndex);



        // Set the player ID, add one to the index to start at Player 1
        playerInput.gameObject.GetComponent<Bike>().playerID = playerInput.playerIndex + 1;

        if (playerInput.playerIndex == 0)
        {
            child = Instantiate(AI);
            child.GetComponent<EnemyAI>().startPos = spawnLocations[1].position;
        } else
        {
            Destroy(child);
        }

        // Set the start spawn position of the player using the location at the associated element into the array.
        playerInput.gameObject.GetComponent<Bike>().startPos = spawnLocations[playerInput.playerIndex].position;

    }
}
