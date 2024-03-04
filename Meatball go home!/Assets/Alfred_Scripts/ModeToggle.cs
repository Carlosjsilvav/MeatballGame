using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is a component of the Audio Source bc it is always active between scenes

public class ModeToggle : MonoBehaviour
{
    /* public bool timeTrialOn;

    GameObject toggle;

    void Start()
    {
        timeTrialOn = false;
        toggle = GameObject.Find("Time Trial Toggle");
        PlayerPrefs.SetInt("timeTrialOn", (timeTrialOn ? 1 : 0));
        timeTrialOn = (PlayerPrefs.GetInt("timeTrialOn") != 0);
    }

    public void timeTrialToggle()
    {
        if (timeTrialOn)
        {
            Debug.Log("Off");
        }
        else
        {
            Debug.Log("On");
        }
    }

    public void timeTrialToggle()
    {
        timeTrialConfirm = true;
        Debug.Log("Time Trial ON");
        Debug.Log();
    } */

    // Start is called before the first frame update
    /* public void Start()
    {
        bool timeTrialConfirm = false;
        bool freeRoamConfirm = false;

        if(PlayerPrefs.GetInt("timeTrialConfirm") == 1)
        {
            timeTrialConfirm = true;
        }
        else
        {
            timeTrialConfirm = false;
        }
        //toggle.isOn = IsOn;
    }

    private void Update()
    {
        if(toggle.isOn)
        {
            PlayerPrefs.SetInt("timeTrialConfirm", 1);
        }
        else
        {
            PlayerPrefs.SetInt("timeTrialConfirm", 0);
        }
    } */
}
