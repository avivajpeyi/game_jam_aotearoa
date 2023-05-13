using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SOEvents", menuName = "SOs/Events")]
public class ScriptableEvents : ScriptableObject
{
    public delegate void Score(int scoreToAdd);
    public event Score eventScore;

    public void OnScoreEvent(int scoreToAdd) {
        if (eventScore != null) {
            eventScore(scoreToAdd);
        }
    }

    
}
