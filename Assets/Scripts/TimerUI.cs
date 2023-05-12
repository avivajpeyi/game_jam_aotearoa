using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class TimerUI : MonoBehaviour
{
    private Timer timer;
    private TMP_Text timerText; // Use TMP_Text instead of Text

    private void Start()
    {
        timer = FindObjectOfType<Timer>();
        timerText = GetComponent<TMP_Text>(); // Use GetComponent<TMP_Text>() for TextMeshPro

        if (timerText == null)
        {
            Debug.LogError("TimerUI: No TMP_Text component found.");
        }
    }

    private void Update()
    {
        if (timerText != null)
        {
            timerText.text = FormatTime(timer.totalTime);
        }
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);

        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}


