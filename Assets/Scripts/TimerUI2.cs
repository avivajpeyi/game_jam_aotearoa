using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerUI2 : MonoBehaviour
{
    private Timer2 timer;
    private TMP_Text timerText; // Use TMP_Text instead of Text

    private void Start()
    {
        timer = FindObjectOfType<Timer2>();
        timerText = GetComponent<TMP_Text>(); // Use GetComponent<TMP_Text>() for TextMeshPro
    }

    private void Update()
    {
        timerText.text = FormatTime(timer.totalTime);
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        int milliseconds = Mathf.FloorToInt((time * 1000f) % 1000f);

        return string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }
}

