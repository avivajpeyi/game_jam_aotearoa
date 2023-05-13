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
        if (timer2D.finished)
        {
            ScriptableEvents.TriggerTimeout2D();
            TriggerGameOver();
        }

        if (timer3D.finished)
        {
            ScriptableEvents.TriggerTimeout3D();
            TriggerGameOver();
        }
    }

    void TriggerGameOver()
    {
        ScriptableEvents.TriggerEndGame();
        Destroy(timer3D);
        Destroy(timer2D);
        Destroy(this);
    }
}