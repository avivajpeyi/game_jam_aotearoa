using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    public Timer timer3D;
    public Timer timer2D;

    public float addedTime;

    private void Start()
    {
        // Assuming the Timer script is attached to the GameController object,
        // you can access it in the Start method

        // Start the timer initially
        //timer.StartTimer();
        //timer2.StartTimer();
    }

    public void StartGame()
    {
        timer3D.StartTimer();
        timer2D.StartTimer();
        timer2D.PauseTimer();
    }

    public void SwitchTimer()
    {
        // Not sure how to make this one function 
    }

    public void AddToTimer3D()
    {
        timer3D.AddTime(addedTime);
        Debug.Log("Added 10 seconds to the timer.");
    }

    public void AddToTimer2D()
    {
        timer2D.AddTime(addedTime);
        Debug.Log("Added 10 seconds to the timer.");
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
