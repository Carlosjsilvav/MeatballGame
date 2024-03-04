using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FreeRoamMode : MonoBehaviour
{
    public bool FreeRoam;
    public GameObject Fork;
    //public bool timerActive = true;

    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if (FreeRoam)
        {
            Fork.SetActive(false);
        }
    }
}
