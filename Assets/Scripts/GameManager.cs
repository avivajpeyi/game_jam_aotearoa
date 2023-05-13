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

    [SerializeField] bool testMode = true;
    [SerializeField] static bool is3D = false;

    // Start is called before the first frame update
    void Start()
    {
        // _timerController.start();
        ScriptableEvents.eventScore += AddScore;
        ScriptableEvents.eventActivate2D += Set2D;
        ScriptableEvents.eventActivate3D += Set3D;



        ScriptableEvents.OnActivate3D();
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: 
        if (testMode)
        {
            if (!is3D && Input.GetKeyDown(KeyCode.Alpha3)) // the 3 key
            {
                ScriptableEvents.OnActivate3D();
            }
            else if (is3D && Input.GetKeyDown(KeyCode.Alpha2))
            {
                ScriptableEvents.OnActivate2D();
            }
        }
    }

    public void OnDestroy()
    {
        ScriptableEvents.eventScore -= AddScore;
        ScriptableEvents.eventActivate2D -= Set2D;
        ScriptableEvents.eventActivate3D -= Set3D;
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
