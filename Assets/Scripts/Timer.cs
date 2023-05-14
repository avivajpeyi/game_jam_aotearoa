using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float totalTime = 10f; // Set the initial time here
    private float maxTime;
    private bool isTimerRunning = false;
    private bool isPaused = false;
    public bool finished;


    void Start()
    {
        maxTime = totalTime;
    }


    private void Update()
    {
        if (isTimerRunning && !isPaused)
        {
            totalTime = Mathf.Clamp(totalTime - Time.deltaTime, 0f, maxTime);
            if (totalTime <= 0f)
                finished = true;
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
        totalTime = Mathf.Clamp(totalTime + time, 0f, maxTime);
    }
    
}