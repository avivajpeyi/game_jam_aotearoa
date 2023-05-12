using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.GetComponent<Obstacle>() != null) {
            Destroy(gameObject);
            return;
        }

        // Check that the object we collided with is the player
        if (other.gameObject.name != "Player") {
            return;
        }

        // TODO: increase the time on the timer here
        

        // Destroy this coin object
        // TODO: add particle/sound fx
        Destroy(gameObject);
    }
    
}
