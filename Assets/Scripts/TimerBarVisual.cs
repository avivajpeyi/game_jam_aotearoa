using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBarVisual : MonoBehaviour
{
    private Timer timer;
    public Slider sliderBar;
    private float initialFillAmount;
    

    private void Start()
    {
        // Assuming the Timer script is attached to the GameController object,
        // you can access it in the Start method
        timer = transform.parent.GetComponent<Timer>();

        // Get the Image component attached to the Fill Area object
        sliderBar = GetComponent<Slider>();

        // Calculate the initial fill amount based on the timer's starting time
        initialFillAmount = timer.totalTime;
        sliderBar.maxValue = initialFillAmount;
        sliderBar.minValue = 0f;
    }

    private void Update()
    {
        // Update the scale of the fill image
        sliderBar.value = timer.totalTime;
    }
    
}
