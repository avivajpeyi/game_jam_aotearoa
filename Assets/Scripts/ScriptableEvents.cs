using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SOEvents", menuName = "SOs/Events")]
public class ScriptableEvents : ScriptableObject
{
    public delegate void Score(float scoreToAdd);
    public static event Score eventScore;

    public static void TriggerScoreEvent(float scoreToAdd)
    {
        if (eventScore != null)
        {
            eventScore(scoreToAdd);
        }
    }

    public delegate void Activate2D();
    public static event Activate2D eventActivate2D;
    public static void TriggerActivate2D()
    {
        if (eventActivate2D != null)
        {
            Debug.Log("Switch to 2D mode: ");
            // print all the subscribers
            foreach (Delegate d in eventActivate2D.GetInvocationList())
            {
                Debug.Log(" >>>  " + d.Method.Name + " triggered");
            }
            eventActivate2D();
        }
    }

    public delegate void Activate3D();
    public static event Activate3D eventActivate3D;
    public static void TriggerActivate3D()
    {
        if (eventActivate3D != null)
        {
            Debug.Log("Switch to 3D mode");
            // print all the subscribers
            foreach (Delegate d in eventActivate2D.GetInvocationList())
            {
                Debug.Log(" >>>  " + d.Method.Name + " triggered");
            }
            eventActivate3D();
            
        }
    }

    public delegate void AddTime2D();
    public static event AddTime2D addTime2D;
    public static void TriggerAddTime2D()
    {
        if (addTime2D != null)
        {
            addTime2D();
        }
    }

    public delegate void AddTime3D();
    public static event AddTime3D addTime3D;
    public static void TriggerAddTime3D()
    {
        if (addTime3D != null) 
        {
            addTime3D();
        }
    }

    public delegate void EndGame();
    public static event EndGame endGame;
    public static void TriggerEndGame()
    {
        if (endGame != null)
        {
            endGame();
        }
    }

    public delegate void ResetScore();
    public static event ResetScore resetScore;
    public static void TriggerResetScore()
    {
        if (resetScore != null)
        {
            resetScore();
        }
    }

    public delegate void ResetGame();
    public static event ResetGame resetGame;
    public static void TriggerResetGame()
    {
        if (resetGame != null)
        {
            resetGame();
        }
    }

    public delegate void StartGame();
    public static event StartGame startGame;
    public static void TriggerStartGame()
    {
        if (startGame != null)
        {
            startGame();
        }
    }
}
