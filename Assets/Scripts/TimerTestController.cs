using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTestController : MonoBehaviour
{
    private Timer timer;

    private void Start()
    {
        // Assuming the Timer script is attached to the GameController object,
        // you can access it in the Start method
        timer = GetComponent<Timer>();

        // Start the timer initially
        timer.StartTimer();
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

        // Press the "R" key to resume the timer
        if (Input.GetKeyDown(KeyCode.R))
        {
            timer.ResumeTimer();
            Debug.Log("Timer resumed.");
        }

        // Press the "A" key to add 10 seconds to the timer
        if (Input.GetKeyDown(KeyCode.A))
        {
            timer.AddTime(10f);
            Debug.Log("Added 10 seconds to the timer.");
        }
    }
}
