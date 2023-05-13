using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SOEvents", menuName = "SOs/Events")]
public class ScriptableEvents : ScriptableObject
{
    public delegate void Score(int scoreToAdd);
    public event Score eventScore;

    public void OnScoreEvent(int scoreToAdd)
    {
        if (eventScore != null)
        {
            eventScore(scoreToAdd);
        }
    }

    public delegate void DDActive();
    public event DDActive eventDDActive;
    public void OnTimerAActive()
    {
        if (eventDDActive != null)
        {
            eventDDActive();
        }
    }

    public delegate void DDDActive();
    public event DDDActive eventDDDActive;
    public void OnTimerBActive()
    {
        if (eventDDDActive != null)
        {
            eventDDDActive();
        }
    }
}
