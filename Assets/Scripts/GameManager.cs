using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] int _score = 0;
    public int Score
    {
        get 
        {
            return this._score;
        }
    }

    [SerializeField] TimerController _timerController;
    

    // Start is called before the first frame update
    void Start()
    {
        // _timerController.start();
        ScriptableEvents.eventScore += AddScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDestroy()
    {
        ScriptableEvents.eventScore -= AddScore;
    }

    void AddScore(int scoreToAdd) {
        _score += scoreToAdd;
    }
}
