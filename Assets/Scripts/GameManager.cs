using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] float _score = 0;
    [SerializeField] TextMeshProUGUI scoreUI;
    [SerializeField] GameObject scoreboardUI;
    [SerializeField] TextMeshProUGUI scoreboardTextUI;
    [SerializeField] List<float> scores = new List<float>();
    [SerializeField] Vector3 scoreboardOffset = new Vector3(900f, 0f, 0f);

    // audio
    [SerializeField] AudioSource bukBukBukBigurkSfx;
    [SerializeField] AudioSource bigigurkSfx;
    [SerializeField] AudioSource chickenSfx;

    public float Score
    {
        get { return this._score; }
    }

    [SerializeField] public static bool testMode = true;
    [SerializeField] public static bool is3D = true;
    private bool gameOver;
    [SerializeField] GameObject gameOverUI;
    [SerializeField] GameObject tutorialUI;
    [SerializeField] GameObject timeout2DUI;
    [SerializeField] GameObject timeout3DUI;
    [SerializeField] bool preStart = true;
    [SerializeField] string scoreFormat = "000";

    [SerializeField] float showPickupForTime = 0.8f;
    [SerializeField] GameObject pickup2DUI;
    [SerializeField] GameObject pickup3DUI;
    [SerializeField] GameObject timer2DalmostOutUI;
    [SerializeField] GameObject timer3DalmostOut;


    private float timeAfterGameOver = 0;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        ScriptableEvents.eventScore += AddScore;
        ScriptableEvents.eventActivate2D += Set2D;
        ScriptableEvents.eventActivate3D += Set3D;


        ScriptableEvents.timeout2D += ShowTimeout2D;
        ScriptableEvents.timeout3D += ShowTimeout3D;
        ScriptableEvents.endGame += GameOver;
        ScriptableEvents.resetGame += Reset;
        ScriptableEvents.startGame += StartGame;

        ScriptableEvents.almostOut2D += Show2DTimerAlmostOut;
        ScriptableEvents.almostOut3D += Show3DTimerAlmostOut;
        ScriptableEvents.addTime2D += Show2DPickupUI;
        ScriptableEvents.addTime3D += Show3DPickupUI;

        scoreboardTextUI.text = "";

    }


    
    public void OnDestroy()
    {
        ScriptableEvents.eventScore -= AddScore;
        ScriptableEvents.eventActivate2D -= Set2D;
        ScriptableEvents.eventActivate3D -= Set3D;

        ScriptableEvents.timeout2D -= ShowTimeout2D;
        ScriptableEvents.timeout3D -= ShowTimeout3D;
        ScriptableEvents.endGame -= GameOver;
        ScriptableEvents.resetGame -= Reset;
        ScriptableEvents.startGame -= StartGame;
        
        ScriptableEvents.almostOut2D -= Show2DTimerAlmostOut;
        ScriptableEvents.almostOut3D -= Show3DTimerAlmostOut;
        ScriptableEvents.addTime2D -= Show2DPickupUI;
        ScriptableEvents.addTime3D -= Show3DPickupUI;
    }

    

    // Update is called once per frame
    void Update()
    {
        // TODO: 

        if (Input.GetKeyDown(KeyCode.F)) // the 3 key
        {
            if (is3D)
            {
                Debug.Log("Switch to 2D mode");
                ScriptableEvents.TriggerActivate2D();
            }
            else
            {
                Debug.Log("Switch to 3D mode");
                ScriptableEvents.TriggerActivate3D();
            }
        }
        

        if (gameOver)
        {
            timeAfterGameOver += Time.deltaTime;
            if (timeAfterGameOver > 1f && Input.anyKey)
            {
                ScriptableEvents.TriggerResetGame();
                Time.timeScale = 0.01f;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        if (preStart && Input.anyKey)
        {
            ScriptableEvents.TriggerStartGame();
        }

        scoreUI.SetText(_score.ToString(scoreFormat));
    }
    


    void AddScore(float scoreToAdd)
    {
        _score += scoreToAdd;
        bigigurkSfx.Play();
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
        gameOver = true;
        scoreboardUI.SetActive(true);
    }

    void Reset()
    {
        gameOverUI.SetActive(false);
        scoreboardUI.SetActive(false);
    }

    void StartGame()
    {
        preStart = false;
        tutorialUI.SetActive(false);
        ScriptableEvents.TriggerActivate3D();
    }

    void ShowTimeout2D()
    {
        timeout2DUI.SetActive(true);
        timeout3DUI.SetActive(false);
        var test = scoreboardUI.transform as RectTransform;
        test.Translate(scoreboardOffset);
        UpdateScoreboard();
    }

    void ShowTimeout3D()
    {
        timeout3DUI.SetActive(true);
        timeout2DUI.SetActive(false);
        var test = scoreboardUI.transform as RectTransform;
        test.Translate(-scoreboardOffset);
        UpdateScoreboard();
    }

    void UpdateScoreboard()
    {
        scores.Add(_score);
        scores.Sort();
        for (int i = 0; i < scores.Count && i < 4; i++)
        {
            scoreboardTextUI.text += (i + 1) + ". " + scores[i].ToString("0") + "<br>";
        }
    }

    IEnumerator ShowTimerNotification(GameObject uiElement, float howLongToShow)
    {
        float duration = howLongToShow;
        float currentTime = 0f;

        uiElement.SetActive(true);
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            yield return null;
        }
        uiElement.SetActive(false);
        yield break;
    }

    void Show2DPickupUI()
    {
        StartCoroutine(ShowTimerNotification(pickup2DUI, showPickupForTime));
    }


    void Show3DPickupUI()
    {
        StartCoroutine(ShowTimerNotification(pickup3DUI, showPickupForTime));
    }

    void Show2DTimerAlmostOut()
    {
        StartCoroutine(ShowTimerNotification(timer2DalmostOutUI, 5f));
    }

    void Show3DTimerAlmostOut()
    {
        StartCoroutine(ShowTimerNotification(timer3DalmostOut, 5f));
    }
}