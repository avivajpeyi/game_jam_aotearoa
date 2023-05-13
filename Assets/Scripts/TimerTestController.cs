using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTestController : MonoBehaviour
{
    private Timer timer;
    private Timer2 timer2;

    private void Start()
    {
        // Assuming the Timer script is attached to the GameController object,
        // you can access it in the Start method
        timer = GetComponent<Timer>();
        timer2 = GetComponent<Timer2>();
        // Start the timer initially
        timer.StartTimer();
        timer2.StartTimer2();
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
            timer2.PauseTimer2();
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
            timer2.ResumeTimer2();
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
            timer2.AddTime2(10f);
            Debug.Log("Added 10 seconds to the timer.");
        }
    }
}
