using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Pickup : MonoBehaviour
{
    bool in3DMode = false;
    
    bool isHidden = false;
    private Collider col;
    private Renderer rend;
    private Material m;

    public GameObject orangeSide;
    public GameObject blueSide;

    private void OnDestroy()
    {
        if (in3DMode)
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
        in3DMode = isFor3d;
        
        Hide();
        if (GameManager.is3D && in3DMode)
        {
            Show();
        }
        else if  (!GameManager.is3D && !in3DMode)
        {
            Show();
        }

        // hacky change the colour of the pickup to red if it's for the 3d timer
        if (in3DMode)
        {
            m.color = Color.red;
        }
        else
        {
            m.color = Color.green;
        }
        
        
        if (in3DMode)
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
            if (in3DMode)
                ScriptableEvents.TriggerAddTime2D();
            else
                ScriptableEvents.TriggerAddTime3D();

            Destroy(gameObject);
        }
    }
}