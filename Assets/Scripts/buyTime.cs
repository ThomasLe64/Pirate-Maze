using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buyTime : MonoBehaviour
{
    public GameObject innerCircle;

    public void addTime()
    {
        if(PlayerPrefs.GetInt("coins") >= 250)
        {
            innerCircle = GameObject.FindWithTag("inner");
            innerCircle.GetComponent<Timer>().time = innerCircle.GetComponent<Timer>().time + 15;
            innerCircle.GetComponent<Timer>().timeAmt = innerCircle.GetComponent<Timer>().timeAmt + 15;
            PlayerPrefs.SetInt("time", PlayerPrefs.GetInt("time") - 1);
            PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") - 250);
        }
    }

}
