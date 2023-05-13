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
    [SerializeField] ScriptableEvents _eventsSO;

    // Start is called before the first frame update
    void Start()
    {
        // _timerController.start();
        _eventsSO.eventScore += AddScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDestroy()
    {
        _eventsSO.eventScore -= AddScore;
    }

    void AddScore(int scoreToAdd) {
        _score += scoreToAdd;
    }
}
