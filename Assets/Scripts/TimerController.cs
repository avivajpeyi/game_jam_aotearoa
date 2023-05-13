using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    public Timer timer3D;
    public Timer timer2D;

    public float addedTime = 2f;


    public void Start()
    {
        timer3D.StartTimer();
        timer2D.StartTimer();
        timer2D.PauseTimer();
        ScriptableEvents.eventActivate2D += Play2DState;
        ScriptableEvents.eventActivate3D += Play3DState;
        
        ScriptableEvents.addTime2D += AddToTimer2D;
        ScriptableEvents.addTime3D += AddToTimer3D;
        
    }
    
    public void OnDestroy()
    {
        ScriptableEvents.eventActivate2D -= Play2DState;
        ScriptableEvents.eventActivate3D -= Play3DState;
    }
    
    public void AddToTimer3D()
    {
        timer3D.AddTime(addedTime);
        Debug.Log("Added time to 3d timer");
    }

    public void AddToTimer2D()
    {
        timer2D.AddTime(addedTime);
        Debug.Log("Added time to 2d timer");
    }

    public void Play3DState()
    {
        timer2D.PauseTimer();
        timer3D.ResumeTimer();
    }

    public void Play2DState()
    {
        timer3D.PauseTimer();
        timer2D.ResumeTimer();
    }

    private void Update()
    {
        // For testing purposes, let's check for user input to trigger certain actions
        if (GameManager.testMode)
        {
            // TestingLogic();
        }
    }

    void TestingLogic()
    {
        // Press the "P" key to pause the timer
        if (Input.GetKeyDown(KeyCode.P))
        {
            timer3D.PauseTimer();
            Debug.Log("Timer paused.");
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            timer2D.PauseTimer();
            Debug.Log("Timer2 paused.");
        }

        // Press the "R" key to resume the timer
        if (Input.GetKeyDown(KeyCode.R))
        {
            timer3D.ResumeTimer();
            Debug.Log("Timer resumed.");
        }

        // Press the "R" key to resume the timer
        if (Input.GetKeyDown(KeyCode.W))
        {
            timer2D.ResumeTimer();
            Debug.Log("Timer resumed.");
        }

        // Press the "A" key to add 10 seconds to the timer
        if (Input.GetKeyDown(KeyCode.A))
        {
            timer3D.AddTime(addedTime);
            Debug.Log("Added 10 seconds to the timer.");
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            timer2D.AddTime(addedTime);
            Debug.Log("Added 10 seconds to the timer.");
        }
    }
}