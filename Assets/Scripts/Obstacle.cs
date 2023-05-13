using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    bool testMode = true;
    private PlayerController _player;

    private void Start () {
        _player = GameObject.FindObjectOfType<PlayerController>();
    }
    
    

    private void OnCollisionEnter (Collision collision)
    {
        if (testMode)
            return;
        
        if (collision.transform.CompareTag("Player")) {
            // Kill the player
            Debug.Log("Collided into an obstacle!");
        }
    }
}
