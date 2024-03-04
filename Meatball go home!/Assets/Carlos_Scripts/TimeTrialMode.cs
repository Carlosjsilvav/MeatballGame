using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeTrialMode : MonoBehaviour
{
    public bool TimedMode;
    public float currentTime = 0f;
    //public bool timerActive = true;

    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if (TimedMode)
        {
            currentTime += Time.deltaTime; // Increment the timer by the time passed since the last frame
        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 200, 20), "Time: " + currentTime.ToString("F2")); // Display the timer on the screen
    }
}
