using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{
    
    public float moveSpeed = 5.0f; // Adjust this to control the movement speed.

    void Update()
    {
        // Get input from the player's keyboard.
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement direction.
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // Calculate the movement vector and scale it by the moveSpeed.
        Vector3 movement = moveDirection * moveSpeed * Time.deltaTime;

        // Move the player.
        transform.Translate(movement);

    }
}