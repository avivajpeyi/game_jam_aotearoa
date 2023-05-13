using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SOEvents", menuName = "SOs/Events")]
public class ScriptableEvents : ScriptableObject
{
    public delegate void Score(int scoreToAdd);
    public static event Score eventScore;

    public void OnScoreEvent(int scoreToAdd)
    {
        if (eventScore != null)
        {
            eventScore(scoreToAdd);
        }
    }

    public delegate void Activate2D();
    public static event Activate2D eventActivate2D;
    public void OnActivate2D()
    {
        if (eventActivate2D != null)
        {
            eventActivate2D();
        }
    }

    public delegate void Activate3D();
    public static event Activate3D eventActivate3D;
    public void OnActivate3D()
    {
        if (eventActivate3D != null)
        {
            eventActivate3D();
        }
    }
}
