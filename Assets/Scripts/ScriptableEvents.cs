using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SOEvents", menuName = "SOs/Events")]
public class ScriptableEvents : ScriptableObject
{
    public delegate void Score(int scoreToAdd);
    public static event Score eventScore;

    public static void OnScoreEvent(int scoreToAdd)
    {
        if (eventScore != null)
        {
            eventScore(scoreToAdd);
        }
    }

    public delegate void Activate2D();
    public static event Activate2D eventActivate2D;
    public static void OnActivate2D()
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
    public static void OnActivate3D()
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
    public static void OnAddTime2D()
    {
        if (addTime2D != null)
        {
            addTime2D();
        }
    }
}
