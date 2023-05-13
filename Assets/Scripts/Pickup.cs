using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Pickup : MonoBehaviour
{
    bool isFor3dTimer = false;
    
    bool isHidden = false;
    private Collider col;
    private Renderer rend;
    private Material m;

    

    private void OnDestroy()
    {
        if (isFor3dTimer)
        {
            ScriptableEvents.eventActivate2D -= Hide;
            ScriptableEvents.eventActivate3D -= Show;    
        }
        else
        {
            ScriptableEvents.eventActivate2D -= Show;
            ScriptableEvents.eventActivate3D -= Hide;    
        }
    }


    public void Initialise(bool isFor3d)
    {
        col = GetComponent<Collider>();
        rend = GetComponent<Renderer>();
        m = rend.material;
        isFor3dTimer = isFor3d;
        
        Hide();
        if (GameManager.is3D && isFor3dTimer)
        {
            Show();
        }
        else if  (!GameManager.is3D && !isFor3dTimer)
        {
            Show();
        }

        // hacky change the colour of the pickup to red if it's for the 3d timer
        if (isFor3dTimer)
        {
            m.color = Color.red;
        }
        else
        {
            m.color = Color.green;
        }
        
        
        if (isFor3dTimer)
        {
            ScriptableEvents.eventActivate2D += Hide;
            ScriptableEvents.eventActivate3D += Show;    
        }
        else
        {
            ScriptableEvents.eventActivate2D += Show;
            ScriptableEvents.eventActivate3D += Hide;    
        }
        
    }



    void Hide()
    {
        isHidden = true;
        col.enabled = false;
        rend.enabled = false;
    }

    void Show()
    {
        isHidden = false;
        col.enabled = true;
        rend.enabled = true;
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