using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float totalTime = 10f;  // Set the initial time here

    private bool isTimerRunning = false;
    private bool isPaused = false;

    private void Update()
    {
        if (isTimerRunning && !isPaused)
        {
            totalTime -= Time.deltaTime;
            if (totalTime <= 0f)
            {
                // Timer has reached zero, handle accordingly
                TimerCompleted();
            }
        }
    }

    public void StartTimer()
    {
        isTimerRunning = true;
    }

    public void PauseTimer()
    {
        isPaused = true;
    }

    public void ResumeTimer()
    {
        isPaused = false;
    }

    public void AddTime(float time)
    {
        totalTime += time;
    }

    private void TimerCompleted()
    {
        // Handle timer completion logic here
        Debug.Log("Timer has completed. GAME OVER YEEHAW!");
    }
}


