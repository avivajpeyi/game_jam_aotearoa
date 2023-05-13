using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    public Timer timer;
    public Timer timer2;

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
        timer.StartTimer();
        timer2.StartTimer();
        timer2.PauseTimer();
    }

    public void SwitchTimer()
    {
        // Not sure how to make this one function 
    }

    public void AddToTimer1()
    {
        timer.AddTime(10f);
        Debug.Log("Added 10 seconds to the timer.");
    }

    public void AddToTimer2()
    {
        timer2.AddTime(10f);
        Debug.Log("Added 10 seconds to the timer.");
    }

    public void Play3DState()
    {
        timer2.PauseTimer();
        timer.ResumeTimer();
    }
    public void Play2DState()
    {
        timer.PauseTimer();
        timer2.ResumeTimer();
    }

    private void Update()
    {
        // For testing purposes, let's check for user input to trigger certain actions

        // Press the "P" key to pause the timer
        if (Input.GetKeyDown(KeyCode.P))
        {
            timer.PauseTimer();
            Debug.Log("Timer paused.");
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            timer2.PauseTimer();
            Debug.Log("Timer2 paused.");
        }

        // Press the "R" key to resume the timer
        if (Input.GetKeyDown(KeyCode.R))
        {
            timer.ResumeTimer();
            Debug.Log("Timer resumed.");
        }

        // Press the "R" key to resume the timer
        if (Input.GetKeyDown(KeyCode.W))
        {
            timer2.ResumeTimer();
            Debug.Log("Timer resumed.");
        }

        // Press the "A" key to add 10 seconds to the timer
        if (Input.GetKeyDown(KeyCode.A))
        {
            timer.AddTime(10f);
            Debug.Log("Added 10 seconds to the timer.");
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            timer2.AddTime(10f);
            Debug.Log("Added 10 seconds to the timer.");
        }
    }
}
