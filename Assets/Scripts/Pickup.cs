using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    bool isFor3dTimer = false;
    
    
    


    public void Start()
    {
        
        
        isFor3dTimer = GameManager.is3D; // TODO: set using GameManager.is3d; 
        Material m = GetComponent<Renderer>().material;
        // hacky change the colour of the pickup to red if it's for the 3d timer
        if (isFor3dTimer)
        {
            m.color = Color.red;
        }
        else
        {
            m.color = Color.green;
        }
    }

    private void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.GetComponent<Obstacle>() != null)
        {
            // If i fucked up and placed the pickup inside an obstacle lol
            Destroy(gameObject);
        }
        // Check that the object we collided with is the player
        else if (other.gameObject.CompareTag("Player"))
        {
            // TODO: increase the time on the timer here
            // TODO: add particle/sound fx

            if (isFor3dTimer)
            {
                // TODO: @nzkieran Start increase 3D timer event
                Debug.Log("Increase 3d timer");
            }
            else
            {
                // TODO: @nzkieran Start increase 3D timer event
                Debug.Log("Increase 2d timer");
            }

            Destroy(gameObject);
        }
    }
}