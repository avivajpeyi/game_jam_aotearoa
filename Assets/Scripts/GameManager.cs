using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] float _score = 0;
    public float Score
    {
        get 
        {
            return this._score;
        }
    }

    [SerializeField] public static bool testMode = true;
    [SerializeField] public  static bool is3D = true;
    [SerializeField] GameObject gameOverUI;

    // Start is called before the first frame update
    void Start()
    {

        ScriptableEvents.eventScore += AddScore;
        ScriptableEvents.eventActivate2D += Set2D;
        ScriptableEvents.eventActivate3D += Set3D;

        ScriptableEvents.endGame += GameOver;
        ScriptableEvents.resetGame =+ Reset;


        ScriptableEvents.TriggerActivate3D();
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: 
        if (testMode)
        {
            if (!is3D && Input.GetKeyDown(KeyCode.Alpha3)) // the 3 key
            {
                Debug.Log("Switch to 3D mode");
                ScriptableEvents.TriggerActivate3D();
            }
            else if (is3D && Input.GetKeyDown(KeyCode.Alpha2))
            {
                ScriptableEvents.TriggerActivate2D();
            }
        }
    }

    public void OnDestroy()
    {
        ScriptableEvents.eventScore -= AddScore;
        ScriptableEvents.eventActivate2D -= Set2D;
        ScriptableEvents.eventActivate3D -= Set3D;

        ScriptableEvents.endGame -= GameOver;
        ScriptableEvents.resetGame -= Reset;

    }

    void AddScore(float scoreToAdd)
    {
        _score += scoreToAdd;
    }

    void ResetScore()
    {
        _score = 0;
    }

    void Set3D()
    {
        is3D = true;
    }

    void Set2D()
    {
        is3D = false;
    }

    void GameOver()
    {
        gameOverUI.SetActive(true);
    }

    void Reset()
    {
        gameOverUI.SetActive(false);
    }
}
