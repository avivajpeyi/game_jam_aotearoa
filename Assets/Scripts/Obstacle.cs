using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    private PlayerController _player;

    private void Start () {
        _player = GameObject.FindObjectOfType<PlayerController>();
    }
    
    

    private void OnCollisionEnter (Collision collision)
    {
        if (collision.transform.CompareTag("Player")) {
            // Kill the player
            Debug.Log("Collided into an obstacle!");
        }
    }
}
