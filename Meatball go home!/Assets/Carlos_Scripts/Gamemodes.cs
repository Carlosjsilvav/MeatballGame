using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemodes : MonoBehaviour
{
    public bool FreeRoam;
    public bool TimedMode;
    public GameObject Fork;
    public float currentTime = 0f;
    public bool timerActive = true;


    private void FixedUpdate()
    {
        if (FreeRoam == true)
        {
            Fork.SetActive(false);
        }

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
