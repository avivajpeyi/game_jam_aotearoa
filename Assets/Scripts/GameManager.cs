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
    [SerializeField] bool testMode = true;
    [SerializeField] static bool is3D = false;

    // Start is called before the first frame update
    void Start()
    {
        // _timerController.start();
        _eventsSO.eventScore += AddScore;
        _eventsSO.eventActivate2D += Set2D;
        _eventsSO.eventActivate3D += Set3D;



        // _eventsSO.eventActivate3D();
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: 
        if (testMode)
        {
            if (!is3D && Input.GetKeyDown(KeyCode.Alpha3)) // the 3 key
            {
                // _eventsSO.eventActivate3D();
            }
            else if (is3D && Input.GetKeyDown(KeyCode.Alpha2))
            {
                // _eventsSO.eventActivate2D();
            }
        }
    }

    public void OnDestroy()
    {
        _eventsSO.eventScore -= AddScore;
        _eventsSO.eventActivate2D -= Set2D;
        _eventsSO.eventActivate3D -= Set3D;
    }

    void AddScore(int scoreToAdd) {
        _score += scoreToAdd;
    }

    void Set3D()
    {
        is3D = true;
    }

    void Set2D()
    {
        is3D = false;
    }
}
