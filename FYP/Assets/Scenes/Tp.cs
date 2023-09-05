using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tp : MonoBehaviour
{
    [SerializeField] Transform tp;
    [SerializeField] GameObject player;
    
    // Define a KeyCode for triggering the teleport (you can change this to any key)
    public KeyCode teleportKey = KeyCode.T;

    private bool isTeleporting = false;
    private Vector3 playerSpawnPoint; // Store the player's spawn point

    private void Start()
    {
        // Store the initial spawn point
        playerSpawnPoint = player.transform.position;
    }

    private void Update()
    {
        // Check if the teleport key is pressed and teleport is not in progress
        if (!isTeleporting && Input.GetKeyDown(teleportKey))
        {
            StartCoroutine(Teleport());
        }
    }

    IEnumerator Teleport()
    {
        // Set isTeleporting to true to prevent further teleports
        isTeleporting = true;

        // Ensure the OnTriggerEnter method won't trigger during teleport
        GetComponent<Collider>().enabled = false;

        // Wait for a short duration before teleporting
        yield return new WaitForSeconds(1);

        // Teleport the player to the specified position
        player.transform.position = new Vector3(
            tp.transform.position.x,
            tp.transform.position.y,
            tp.transform.position.z
        );

        // Update the player's spawn point to the new location
        playerSpawnPoint = player.transform.position;

        // Reset isTeleporting after teleporting
        isTeleporting = false;

        // Re-enable the collider to allow further teleportation
        GetComponent<Collider>().enabled = true;
    }

    // You can call this function whenever you want to reset the player's position to the spawn point
    public void ResetPlayerPosition()
    {
        player.transform.position = playerSpawnPoint;
    }
}