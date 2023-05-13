using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SOEvents", menuName = "SOs/Events")]
public class ScriptableEvents : ScriptableObject
{
    public delegate void Score(float scoreToAdd);
    public static event Score eventScore;

    public static void OnScoreEvent(float scoreToAdd)
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
            eventActivate2D();
        }
    }

    public delegate void Activate3D();
    public static event Activate3D eventActivate3D;
    public static void OnActivate3D()
    {
        if (eventActivate3D != null)
        {
            eventActivate3D();
        }
    }

    public delegate void AddTime2D(float timeToAdd);
    public static event AddTime2D addTime2D;
    public static void OnAddTime2D(float timeToAdd)
    {
        if (addTime2D != null)
        {
            addTime2D(timeToAdd);
        }
    }

    public delegate void AddTime3D(float timeToAdd);
    public static event AddTime3D addTime3D;
    public static void OnAddTime3D(float timeToAdd)
    {
        if (addTime3D != null) 
        {
            addTime3D(timeToAdd);
        }
    }
}
