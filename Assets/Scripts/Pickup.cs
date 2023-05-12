using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    private void OnTriggerEnter (Collider other)
    {
        Debug.Log("Triggered!");
        
        if (other.gameObject.GetComponent<Obstacle>() != null) {
            // If i fucked up and placed the pickup inside an obstacle lol
            Destroy(gameObject);
        }
        // Check that the object we collided with is the player
        else if (other.gameObject.CompareTag("Player")) {
            // TODO: increase the time on the timer here
            // TODO: add particle/sound fx
            Destroy(gameObject);
        }
    }
    
}
