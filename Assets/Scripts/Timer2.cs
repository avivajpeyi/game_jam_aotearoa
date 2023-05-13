using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer2 : MonoBehaviour
{
    public float totalTime = 60f;  // Set the initial time here

    private bool isTimer2Running = false;
    private bool isPaused = false;

    private void Update()
    {
        if (isTimer2Running && !isPaused)
        {
            totalTime -= Time.deltaTime;
            if (totalTime <= 0f)
            {
                // Timer has reached zero, handle accordingly
                Timer2Completed();
            }
        }
    }

    public void StartTimer2()
    {
        isTimer2Running = true;
    }

    public void PauseTimer2()
    {
        isPaused = true;
    }

    public void ResumeTimer2()
    {
        isPaused = false;
    }

    public void AddTime2(float time)
    {
        totalTime += time;
    }

    private void Timer2Completed()
    {
        // Handle timer2 completion logic here
    }
}
