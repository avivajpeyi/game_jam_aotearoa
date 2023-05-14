using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Pickup : MonoBehaviour
{
    [SerializeField] bool in3DMode = false;

    bool isHidden = false;
    private Collider col;
    [SerializeField] Renderer[] rends;


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


    public void Start()
    {
        col = GetComponent<Collider>();


        Hide();
        if (GameManager.is3D && in3DMode)
        {
            Show();
        }
        else if (!GameManager.is3D && !in3DMode)
        {
            Show();
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
        foreach (var r in rends)
        {
            r.enabled = false;
        }
    }

    void Show()
    {
        isHidden = false;
        col.enabled = true;
        foreach (var r in rends)
        {
            r.enabled = true;
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
            if (in3DMode)
                ScriptableEvents.TriggerAddTime2D();
            else
                ScriptableEvents.TriggerAddTime3D();

            Destroy(gameObject);
        }
    }
}